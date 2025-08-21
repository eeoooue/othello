
export type Piece = "empty" | "white" | "black";

function intToPiece(n: number): Piece {
  switch (n) {
    case 1:  return "black";
    case -1: return "white";
    default: return "empty";
  }
}

function convertIntegerMatrixToPieces(board: number[][]): Piece[] {
  return board.flat().map(intToPiece);
}

export function getDummyBoard(): number[][] {

    const board: number[][] = [
        [0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0],
        [0, 0, 0, 0, 0, 0, 0, 0],
    ]

    return board;
}

export function createEmptyBoard(): Piece[] {
    return convertIntegerMatrixToPieces(getDummyBoard());
}

export async function getBoardFromApi(): Promise<number[][]> {
    const res = await fetch("http://localhost:8080/othellogame/board", {
        mode: "cors",
        headers: { "Accept": "application/json" },
    });
    if (!res.ok) throw new Error(`Board fetch failed: ${res.status}`);
    const data = await res.json();
    if (Array.isArray(data) && Array.isArray(data[0])) return data as number[][];
    throw new Error("Unexpected board payload shape");
}

export async function loadCurrentBoard(): Promise<Piece[]> {
    const matrix = await getBoardFromApi();
    return convertIntegerMatrixToPieces(matrix);
}
