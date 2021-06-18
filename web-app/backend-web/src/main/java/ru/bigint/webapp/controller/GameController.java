package ru.bigint.webapp.controller;

import org.apache.tomcat.util.http.fileupload.IOUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.core.env.Environment;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.context.support.ServletContextResource;
import org.springframework.web.servlet.ModelAndView;
import ru.bigint.webapp.data.entity.game.Game;
import ru.bigint.webapp.service.iface.game.GameService;

import javax.activation.FileTypeMap;
import javax.annotation.Resource;
import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.nio.file.Files;
import java.util.List;


@Controller
@RequestMapping(value="/games/")
public class GameController {

    private Logger LOGGER = LoggerFactory.getLogger(this.getClass());

    private final GameService gameService;

    @Value("${app.imagesUploadPath}")
    private String imagePath;

    public GameController(GameService gameService) {
        this.gameService = gameService;
    }

    /**
     * Список игр
     * */
    @GetMapping(value="/")
    public ModelAndView showGames() {
        ModelAndView modelAndView = new ModelAndView();
        List<Game> games = gameService.getAll();

        modelAndView.addObject("games", games);
        modelAndView.addObject("imagePath", imagePath);
        modelAndView.setViewName("game/list");
        return modelAndView;
    }


    @GetMapping(value = "/images/{id}/")
    public ResponseEntity<byte[]> getImage(@PathVariable int id) throws IOException{
        Game game = gameService.getById(id);

        File img = new File(imagePath + game.getImage());
        return ResponseEntity.ok().contentType(
                MediaType.valueOf(FileTypeMap.getDefaultFileTypeMap().getContentType(img))).body(Files.readAllBytes(img.toPath())
        );
    }


//    /**
//     * Добавление
//     * */
//    @RequestMapping(value="/post/{id}/", method = RequestMethod.GET)
//    public ModelAndView addLessonForm(@PathVariable Integer id) {
//        Post post = postService.getById(id);
//
//        ModelAndView modelAndView = new ModelAndView();
//        modelAndView.addObject("post", post);
////        modelAndView.addObject("imagePath", env.getProperty("blog.imagesHandlerPath"));
//        modelAndView.setViewName("post/index");
//        return modelAndView;
//    }
}