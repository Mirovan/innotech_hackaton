package ru.bigint.webapp.controller.cabinet;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.ModelAndView;
import ru.bigint.webapp.data.entity.game.Game;
import ru.bigint.webapp.service.iface.game.GameService;
import ru.bigint.webapp.utils.ImageUploader;

import java.util.List;
import java.util.UUID;


@Controller
@RequestMapping(value="/cabinet/games/")
@PreAuthorize("hasRole('ROLE_ADMIN')")
public class CabinetGameController {

    private Logger LOGGER = LoggerFactory.getLogger(this.getClass());

    @Value("${app.imagesUploadPath}")
    private String imagePath;

    private final GameService gameService;

    public CabinetGameController(GameService gameService) {
        this.gameService = gameService;
    }

    /**
     * Список всех игр
     * */
    @GetMapping(value="/")
    public ModelAndView showAll() {
        List<Game> games = gameService.getAll();

        ModelAndView modelAndView = new ModelAndView();
        modelAndView.addObject("games", games);
        modelAndView.setViewName("cabinet/game/index");
        return modelAndView;
    }


    /**
     * Форма для Добавления
     * */
    @GetMapping(value="/add/")
    public ModelAndView newItemForm() {
        Game game = new Game();

        ModelAndView modelAndView = new ModelAndView();
        modelAndView.addObject("game", game);
        modelAndView.addObject("action", "add");
//        modelAndView.addObject("formAction", "/cabinet/game/add/");
        modelAndView.setViewName("cabinet/game/edit");
        return modelAndView;
    }


    /**
     * Добавление
     * */
    @PostMapping(value="/add/")
    public ModelAndView newItemSave(@ModelAttribute Game game, @RequestParam(value = "imageFile", required = false) MultipartFile imageFile) {
        String imageName = UUID.randomUUID() + ".png";
        game.setImage(imageName);
        gameService.add(game);

        //Сохраняем фото
        ImageUploader.upload(imageFile, imagePath + "/" + imageName);

        return new ModelAndView("redirect:/cabinet/games/");
    }


    /**
     * Форма для Редактирования поста
     * */
    @GetMapping(value="/{id}/edit/")
    public ModelAndView editItemForm(@PathVariable Integer id) {
        Game game = gameService.getById(id);

        ModelAndView modelAndView = new ModelAndView();
        modelAndView.addObject("game", game);
        modelAndView.addObject("action", "edit");
        modelAndView.addObject("formAction", "/cabinet/game/edit/");
        modelAndView.setViewName("cabinet/game/edit");
        return modelAndView;
    }


    /**
     * Редактирование поста
     * */
    @PostMapping(value="/edit/")
    public ModelAndView editItemSave(@ModelAttribute Game game, @RequestParam(value = "imageFile", required = false) MultipartFile imageFile) {
        String imageName = UUID.randomUUID().toString() + ".png";
        game.setImage(imageName);
        gameService.update(game);

        //Сохраняем фото
        ImageUploader.upload(imageFile, imagePath + "/" + imageName);

        return new ModelAndView("redirect:/cabinet/games/");
    }

}