import "./GameTile.css";
import type { Piece } from "../services/BoardService";

type GameTileProps = {
  piece: Piece;
  onClick: () => void;
};

export default function GameTile({ piece, onClick }: GameTileProps) {
  return (
    <div className="tile" onClick={onClick}>
      {piece !== "empty" && (
        <div className={`piece piece-${piece}`} />
      )}
    </div>
  );
}
