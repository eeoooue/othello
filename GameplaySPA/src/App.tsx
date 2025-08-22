import './App.css'
import { useState } from "react";
import { useEffect } from 'react';

import NavBar from './components/NavBar';
import GameInterface from './components/GameInterface';
import { createEmptyBoard, loadCurrentBoard } from './services/BoardService';
import type { Piece } from './services/BoardService';
import { submitMove } from "./services/MoveService";
import { GameInfo, getDummyGameInfo, getGameInfoFromApi } from './services/GameInfoService';

function App() {
  const [tiles, setTiles] = useState<Piece[]>(() => createEmptyBoard());
  const [gameInfo, setGameInfo] = useState<GameInfo>(() => getDummyGameInfo());

  useEffect(() => {
    loadCurrentBoard().then(setTiles).catch(console.error);
  }, []);

  useEffect(() => {
    getGameInfoFromApi().then(setGameInfo).catch(console.error);
  }, []);

  const handleTileClick = (i: number, j: number, player = 1) => {
    submitMove(player, i, j)
    .then(() => Promise.all([
      loadCurrentBoard().then(setTiles),
      getGameInfoFromApi().then(setGameInfo)
    ]))
    .catch(console.error);

    submitMove(player * -1, i, j)
    .then(() => Promise.all([
      loadCurrentBoard().then(setTiles),
      getGameInfoFromApi().then(setGameInfo)
    ]))
    .catch(console.error);
  };
  
  return (
    <>
      <NavBar />
      <main className="container">
        <GameInterface tiles={tiles} gameInfo={gameInfo} onTileClick={handleTileClick}/>
      </main>
    </>
  );
}

export default App;