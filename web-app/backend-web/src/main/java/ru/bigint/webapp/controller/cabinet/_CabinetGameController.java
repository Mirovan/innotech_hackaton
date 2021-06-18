//package ru.bigint.webapp.controller.cabinet;
//
//import org.slf4j.Logger;
//import org.slf4j.LoggerFactory;
//import org.springframework.stereotype.Controller;
//
//
//@Controller
//public class _CabinetGameController {
//
//    private Logger LOGGER = LoggerFactory.getLogger(this.getClass());
//
////    @Autowired
////    private CategoryService categoryService;
//
//
//    /**
//     * Список категорий
//     * */
////    @RequestMapping(value="/cabinet/categories/", method = RequestMethod.GET)
////    @PreAuthorize("hasRole('ROLE_ADMIN')")
////    public ModelAndView showCategories() {
////        ModelAndView modelAndView = new ModelAndView();
////        List<Category> categories = categoryService.getAll();
////
////        modelAndView.addObject("categories", categories);
////        modelAndView.setViewName("cabinet/category/index");
////        return modelAndView;
////    }
//
//
//    /**
//     * Форма для Добавления категории
//     * */
////    @RequestMapping(value="/cabinet/category/add/", method = RequestMethod.GET)
////    @PreAuthorize("hasRole('ROLE_ADMIN')")
////    public ModelAndView addCategoryForm() {
////        Category category = new Category();
////
////        ModelAndView modelAndView = new ModelAndView();
////        modelAndView.addObject("category", category);
////        modelAndView.addObject("action", "add");
////        modelAndView.addObject("formAction", "/cabinet/category/add/");
////        modelAndView.setViewName("cabinet/category/edit");
////        return modelAndView;
////    }
//
//
//    /**
//     * Добавление категории
//     * */
////    @RequestMapping(value="/cabinet/category/add/", method = RequestMethod.POST)
////    @PreAuthorize("hasRole('ROLE_ADMIN')")
////    public ModelAndView addCategorySave(@ModelAttribute Category category) {
////        categoryService.add(category);
////
////        return new ModelAndView("redirect:/cabinet/categories/");
////    }
//
//
//    /**
//     * Форма для Редактирования Категории
//     * */
////    @RequestMapping(value="/cabinet/category/{id}/edit/", method = RequestMethod.GET)
////    @PreAuthorize("hasRole('ROLE_ADMIN')")
////    public ModelAndView editCategoryForm(@PathVariable Integer id) {
////        Category category = this.categoryService.getById(id);
////
////        ModelAndView modelAndView = new ModelAndView();
////        modelAndView.addObject("category", category);
////        modelAndView.addObject("action", "edit");
////        modelAndView.addObject("formAction", "/cabinet/category/" + id + "edit/");
////        modelAndView.setViewName("cabinet/category/edit");
////        return modelAndView;
////    }
//
//
//    /**
//     * Редактирование Категории
//     * */
////    @RequestMapping(value="/cabinet/category/edit/", method = RequestMethod.POST)
////    @PreAuthorize("hasRole('ROLE_ADMIN')")
////    public ModelAndView editCategorySave(@ModelAttribute Category category) {
////        this.categoryService.update(category);
////
////        return new ModelAndView("redirect:/cabinet/categories/");
////    }
//
//}