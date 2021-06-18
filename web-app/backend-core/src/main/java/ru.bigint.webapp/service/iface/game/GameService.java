package ru.bigint.webapp.service.iface.game;

import ru.bigint.webapp.data.entity.game.Game;

import java.util.List;

public interface GameService {
    Game getById(Integer id);
    Game add(Game game);
    Game update(Game game);
    List<Game> getAll();
}
