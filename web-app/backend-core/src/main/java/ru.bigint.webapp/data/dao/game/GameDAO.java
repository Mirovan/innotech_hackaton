package ru.bigint.webapp.data.dao.game;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import ru.bigint.webapp.data.entity.game.Game;

@Repository("gameDAO")
public interface GameDAO extends JpaRepository<Game, Integer> {
}