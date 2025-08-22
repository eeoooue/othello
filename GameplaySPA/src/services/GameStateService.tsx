
import { loadCurrentBoard, type Piece } from "./BoardService";
import { getGameInfoFromApi, type GameInfo } from "./GameInfoService";

export async function fetchGameState(): Promise<{ tiles: Piece[]; gameInfo: GameInfo }> {
  const [tiles, gameInfo] = await Promise.all([loadCurrentBoard(), getGameInfoFromApi()]);

  if (gameInfo.TurnPlayer == -1){
    const n: number = tiles.length;
    for(let i=0; i<n; i++){
      if (tiles[i] == "option"){
        tiles[i] = "empty";
      }
    }
  }

  return { tiles, gameInfo };
}

