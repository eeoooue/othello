import { useState } from "react";
import GameTile from "./GameTile";
import "./GameBoard.css";

type Piece = "empty" | "white" | "black";

export default function GameBoard() {
  const [tiles, setTiles] = useState<Piece[]>(
    Array(64).fill("empty")
  );

  function next(p: Piece): Piece {
    if (p === "empty") return "white";
    if (p === "white") return "black";
    return "empty";
  }

  function toggleTile(i: number) {
    setTiles(prev => prev.map((t, idx) => (idx === i ? next(t) : t)));
  }

  return (
    <div className="game-board">
      <div className="grid">
        {tiles.map((piece, i) => (
          <GameTile key={i} piece={piece} onClick={() => toggleTile(i)} />
        ))}
      </div>
    </div>
  );
}
