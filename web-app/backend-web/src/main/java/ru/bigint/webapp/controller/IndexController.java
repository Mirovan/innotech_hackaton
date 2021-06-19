package ru.bigint.webapp.controller;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;
import ru.bigint.webapp.data.entity.game.Game;
import ru.bigint.webapp.service.iface.game.GameService;

import java.util.List;


@Controller
public class IndexController {

    private Logger LOGGER = LoggerFactory.getLogger(this.getClass());

    private final GameService gameService;

    public IndexController(GameService gameService) {
        this.gameService = gameService;
    }

    @RequestMapping(value="/", method = RequestMethod.GET)
    public ModelAndView index() {
        ModelAndView modelAndView = new ModelAndView();

        List<Game> games = gameService.getAll();

        modelAndView.addObject("games", games);

        modelAndView.setViewName("index");
        return modelAndView;
    }

}
