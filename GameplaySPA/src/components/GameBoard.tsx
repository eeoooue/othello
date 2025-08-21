import GameTile from "./GameTile";
import "./GameBoard.css";

// GameBoard.tsx
type Piece = "empty" | "white" | "black"

export default function GameBoard({
  tiles,
  onToggle,
}: {
  tiles: Piece[]
  onToggle: (i: number) => void
}) {
  return (
    <div className="game-board">
      <div className="grid">
        {tiles.map((piece, i) => (
          <GameTile key={i} piece={piece} onClick={() => onToggle(i)} />
        ))}
      </div>
    </div>
  )
}

