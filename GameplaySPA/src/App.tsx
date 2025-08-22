import './App.css'
import { useState } from "react";
import { useEffect } from 'react';

import NavBar from './components/NavBar';
import GameInterface from './components/GameInterface';
import { createEmptyBoard, loadCurrentBoard } from './services/BoardService';
import type { Piece } from './services/BoardService';
import { submitMove, startNewGame } from "./services/MoveService";
import { GameInfo, getDummyGameInfo, getGameInfoFromApi } from './services/GameInfoService';

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
    submitMove(gameInfo.TurnPlayer, i, j)
      .then(refreshGameState)
      .catch(console.error);
  };

  const handleResetClick = () => {
    startNewGame()
      .then(refreshGameState)
      .catch(console.error);
  };
  
  return (
    <>
      <NavBar />
      <main className="container">
        <GameInterface tiles={tiles} gameInfo={gameInfo} onTileClick={handleTileClick} onReset={handleResetClick}/>
      </main>
    </>
  );
}

export default App;