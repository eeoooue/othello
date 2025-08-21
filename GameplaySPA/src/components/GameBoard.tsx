import GameTile from "./GameTile";
import "./GameBoard.css";
import type { Piece } from "../services/BoardService";

export default function GameBoard({
  tiles,
  onTileClick,
}: {
  tiles: Piece[];
  onTileClick: (i: number, j: number) => void;
}) {
  return (
    <div className="game-board">
      <div className="grid">
        {tiles.map((piece, idx) => {
          const i = Math.floor(idx / 8);
          const j = idx % 8;
          return (
            <GameTile
              key={idx}
              piece={piece}
              onClick={() => onTileClick(i, j)}
            />
          );
        })}
      </div>
    </div>
  );
}
