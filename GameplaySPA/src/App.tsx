import './App.css'
import { useState } from "react";
import { useEffect } from 'react';

import NavBar from './components/NavBar';
import GameInterface from './components/GameInterface';
import { createEmptyBoard } from './services/BoardService';
import type { Piece } from './services/BoardService';
import { submitMove, startNewGame, submitPass } from "./services/MoveService";
import { GameInfo, getDummyGameInfo } from './services/GameInfoService';

import { fetchGameState } from './services/GameStateService';

function App() {
  const [tiles, setTiles] = useState<Piece[]>(() => createEmptyBoard());
  const [gameInfo, setGameInfo] = useState<GameInfo>(() => getDummyGameInfo());

  const refreshGameState = async () => {
    const { tiles, gameInfo } = await fetchGameState();
    setTiles(tiles);
    setGameInfo(gameInfo);
  };

  useEffect(() => { refreshGameState().catch(console.error); }, []);

  const handleTileClick = (i: number, j: number) => {
    submitMove(1, i, j) // '1' here forces playing as black only
      .then(refreshGameState)
      .catch(console.error);
  };

  const handlePassClick = () => {
    submitPass(gameInfo.TurnPlayer)
      .then(refreshGameState)
      .catch(console.error);
  };

  const handleResetClick = () => {
    startNewGame()
      .then(refreshGameState)
      .catch(console.error);
  };

  useEffect(() => {
    let cancelled = false;
    let fetching = false;

    const tick = async () => {
      if (fetching) return;
      fetching = true;
      try {
        const { tiles, gameInfo } = await fetchGameState();
        if (!cancelled) {
          setTiles(tiles);
          setGameInfo(gameInfo);
        }
      } finally {
        fetching = false;
      }
    };

    tick();
    const id = setInterval(tick, 800);
    return () => { cancelled = true; clearInterval(id); };
  }, []);

  return (
    <>
      <NavBar />
      <main className="container">
        <GameInterface tiles={tiles} gameInfo={gameInfo} onTileClick={handleTileClick} onPass={handlePassClick} onReset={handleResetClick} />
      </main>
    </>
  );
}

export default App;