package ru.bigint.webapp.controller.cabinet;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.WebDataBinder;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;
import ru.bigint.webapp.data.entity.user.User;
import ru.bigint.webapp.service.iface.user.RoleService;
import ru.bigint.webapp.service.iface.user.UserService;

import javax.validation.Valid;
import java.beans.PropertyEditorSupport;
import java.security.Principal;
import java.sql.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Collections;
import java.util.Date;
import java.util.List;


@Controller
public class CabinetController {

    private Logger LOGGER = LoggerFactory.getLogger(this.getClass());

    private final UserService userService;

    private final RoleService roleService;

    public CabinetController(UserService userService, RoleService roleService) {
        this.userService = userService;
        this.roleService = roleService;
    }


    /**
     * Главная страница Кабинета администратора
     * */
    @RequestMapping(value="/cabinet/", method = RequestMethod.GET)
    @PreAuthorize("hasRole('ROLE_ADMIN')")
    public ModelAndView showCabinet() {
        //Если доступ есть
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setViewName("cabinet/index");
        return modelAndView;
    }


    /**
     * Список пользователей
     * */
    @RequestMapping(value="/cabinet/users/", method = RequestMethod.GET)
    @PreAuthorize("hasRole('ROLE_ADMIN')")
    public ModelAndView showUsers() {
        ModelAndView modelAndView = new ModelAndView();
        List<User> users = userService.getAllByOrder("ASC");

        modelAndView.addObject("users", users);
        modelAndView.setViewName("cabinet/users");
        return modelAndView;
    }


    /**
     * Форма для Добавления пользователя
     * */
    @RequestMapping(value="/cabinet/users/add/", method = RequestMethod.GET)
    @PreAuthorize("hasRole('ROLE_ADMIN')")
    public ModelAndView addUserForm() {
        ModelAndView modelAndView = new ModelAndView();
        User user = new User();
        user.setPassword( userService.generateRandomPassword() );
        modelAndView.addObject("user", user);
        modelAndView.addObject("action", "add");
        modelAndView.addObject("formAction", "/cabinet/users/add/");
        modelAndView.setViewName("cabinet/users/edit");
        return modelAndView;
    }


    /**
     * Добавление пользователя
     * */
    @RequestMapping(value="/cabinet/users/add/", method = RequestMethod.POST)
    @PreAuthorize("hasRole('ROLE_ADMIN')")
    public ModelAndView addUserPost(@ModelAttribute @Valid User user, BindingResult bindingResult) {
        //Если пользователь с таким email уже есть
        User userExists = userService.getByEmail(user.getEmail());
        if (userExists != null) {
            bindingResult
                    .rejectValue("email", "error.user",
                            "There is already a user registered with the email provided");
        }
        //Есть ошибки - открываем форму повторно
        if (bindingResult.hasErrors()) {
            ModelAndView modelAndView = new ModelAndView();
            modelAndView.addObject("user", user);
            modelAndView.addObject("action", "add");
            modelAndView.addObject("formAction", "/cabinet/users/add/");
            modelAndView.setViewName("/cabinet/users/edit");
            return modelAndView;
        } else {
            user.setPassword(userService.encodePassword(user.getPassword()));
            user.setActive(true);
            user.setRoles(Collections.singleton(roleService.findRoleByCode("DEFAULT")));
            userService.add(user);

            return new ModelAndView("redirect:/cabinet/users/");
        }
    }


    /**
     * Форма для Редактирования пользователя
     * */
    @RequestMapping(value="/cabinet/users/{id}/edit/", method = RequestMethod.GET)
    @PreAuthorize("hasRole('ROLE_ADMIN')")
    public ModelAndView editUserForm(@PathVariable("id") Integer id) {
        ModelAndView modelAndView = new ModelAndView();
        User user = userService.getById(id);
        user.setPassword("");
        modelAndView.addObject("user", user);
        modelAndView.addObject("action", "edit");
        modelAndView.addObject("formAction", "/cabinet/users/" + user.getId() + "/edit/");
        modelAndView.setViewName("/cabinet/users/edit");
        return modelAndView;
    }


    /**
     * Редактирование пользователя
     * */
    @RequestMapping(value="/cabinet/users/{id}/edit/", method = RequestMethod.POST)
    @PreAuthorize("hasRole('ROLE_ADMIN')")
    public ModelAndView editUserPost(@PathVariable Integer id, @ModelAttribute User updateUser, BindingResult bindingResult) {
        //Кого обновляем
        User user = userService.getById(id);

        //Если пользователь с таким email уже есть
        User userExists = userService.getByEmail(user.getEmail());
        if (userExists != null && userExists.getId() != user.getId()) {
            bindingResult
                    .rejectValue("email", "error.user",
                            "There is already a user registered with the email provided");
        }
        //Есть ошибки - открываем форму повторно
        if (bindingResult.hasErrors()) {
            user.setPassword("");
            ModelAndView modelAndView = new ModelAndView();
            modelAndView.addObject("user", user);
            modelAndView.addObject("action", "edit");
            modelAndView.addObject("formAction", "/cabinet/users/" + user.getId() + "/edit/");
            modelAndView.setViewName("/cabinet/users/edit");
            return modelAndView;
        } else {
            userService.update(user, updateUser);
            return new ModelAndView("redirect:/cabinet/users/");
        }
    }

}