
import { loadCurrentBoard, type Piece } from "./BoardService";
import { getGameInfoFromApi, type GameInfo } from "./GameInfoService";

export async function fetchGameState(): Promise<{ tiles: Piece[]; gameInfo: GameInfo }> {
  const [tiles, gameInfo] = await Promise.all([loadCurrentBoard(), getGameInfoFromApi()]);
  return { tiles, gameInfo };
}

