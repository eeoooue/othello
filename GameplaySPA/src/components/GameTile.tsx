import "./GameTile.css";

type Piece = "empty" | "white" | "black";

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
