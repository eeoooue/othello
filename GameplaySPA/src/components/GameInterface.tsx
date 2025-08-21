// GameInterface.tsx
import './GameInterface.css'
import GameBoard from './GameBoard'
import GameSidePanel from './GameSidePanel'
import type { Dispatch, SetStateAction } from 'react'

type Piece = "empty" | "white" | "black"

// optional: keep your toggle here or in GameBoard
const next = (p: Piece): Piece =>
  p === "empty" ? "white" : p === "white" ? "black" : "empty"

export default function GameInterface({
  tiles,
  setTiles,
}: {
  tiles: Piece[]
  setTiles: Dispatch<SetStateAction<Piece[]>>
}) {
  const onToggle = (i: number) =>
    setTiles(prev => prev.map((t, idx) => (idx === i ? next(t) : t)))

  return (
    <div className="game-interface">
      <GameBoard tiles={tiles} onToggle={onToggle} />
      <GameSidePanel />
    </div>
  )
}
