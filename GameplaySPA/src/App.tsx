import './App.css'
import { useState } from "react";
import { useEffect } from 'react';

import NavBar from './components/NavBar';
import GameInterface from './components/GameInterface';
import { createEmptyBoard, loadCurrentBoard } from './services/BoardService';
import type { Piece } from './services/BoardService';
import { submitMove } from "./services/MoveService";

function App() {
  const [tiles, setTiles] = useState<Piece[]>(() => createEmptyBoard());

  useEffect(() => {
    loadCurrentBoard().then(setTiles).catch(console.error);
  }, []);

  const handleTileClick = (i: number, j: number, player = 1) => {
    submitMove(player, i, j)
      .then(() => loadCurrentBoard().then(setTiles))
      .catch(console.error);

    submitMove(player * -1, i, j) // temporary way to play as either player
      .then(() => loadCurrentBoard().then(setTiles))
      .catch(console.error);
  };
  
  return (
    <>
      <NavBar />
      <main className="container">
        <GameInterface tiles={tiles} onTileClick={handleTileClick} />
      </main>
    </>
  );
}

export default App;