package ru.bigint.webapp.service.impl.game;


import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Service;
import ru.bigint.webapp.data.dao.game.GameDAO;
import ru.bigint.webapp.data.entity.game.Game;
import ru.bigint.webapp.service.iface.game.GameService;

import java.util.List;

@Service("categoryService")
public class GameServiceImpl implements GameService {

    private final Logger LOGGER = LoggerFactory.getLogger(this.getClass());

    private final GameDAO gameDAO;

    public GameServiceImpl(GameDAO gameDAO) {
        this.gameDAO = gameDAO;
    }

    @Override
    public Game getById(Integer id) {
        return gameDAO.findById(id).get();
    }

    @Override
    public Game add(Game game) {
        game = gameDAO.save(game);
        return game;
    }

    @Override
    public Game update(Game game) {
        game = gameDAO.save(game);
        return game;
    }

    @Override
    public List<Game> getAll() {
        return gameDAO.findAll();
    }
}