package ru.bigint.webapp.controller.api;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;
import ru.bigint.webapp.utils.LoggerUtil;

import javax.servlet.http.HttpServletRequest;


@RestController
@RequestMapping(value="/api/v1/score")
public class ScoreController {

    private Logger LOGGER = LoggerFactory.getLogger(this.getClass());

    @PutMapping("/update/{userId}/game/{gameId}/score/{score}")
    public void updateScore(@PathVariable Integer userId, @PathVariable Integer gameI, @PathVariable Integer score) {
        //ToDo: реализовать обновление счета человека для конкретной игры
    }

}