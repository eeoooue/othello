
export async function submitMove(player: number, i: number, j: number): Promise<void> {
  const res = await fetch("http://localhost:8080/othellogame/move", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      Accept: "application/json",
    },
    body: JSON.stringify({ player, i, j }),
  });

  if (!res.ok) {
    const text = await res.text();
    throw new Error(`Move failed (${res.status}): ${text}`);
  }
}


export async function submitPass(player: number): Promise<void> {
  const res = await fetch(`http://localhost:8080/othellogame/pass?player=${player}`, {
    method: "POST",
  });

  if (!res.ok) {
    const text = await res.text();
    throw new Error(`Move failed (${res.status}): ${text}`);
  }
}


export async function startNewGame(): Promise<void> {
  const res = await fetch("http://localhost:8080/othellogame/newgame", {
    method: "POST",
  });

  if (!res.ok) {
    const text = await res.text();
    throw new Error(`Move failed (${res.status}): ${text}`);
  }
}




