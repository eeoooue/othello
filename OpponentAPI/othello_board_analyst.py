
import numpy as np
import torch
from typing import List

from othello_cnn_model import OthelloResNet

class OthelloBoardAnalyst:
    def __init__(self):

        self.device = torch.device('cuda' if torch.cuda.is_available() else 'cpu')
        self.model = self.load_model()

    def load_model(self):

        MODEL_PATH = "model/othello_eval_cnn.pth"
        model = OthelloResNet()
        model.load_state_dict(torch.load(MODEL_PATH, map_location=self.device, weights_only=False))
        model.to(self.device)
        model.eval()

        return model

    def get_score_for_board_state(self, board: List[List[int]], turn_player: int) -> float:

        matrix = np.array(board, dtype=np.int8)
        normalized_matrix = self.normalize_input_to_turn_player(matrix, turn_player)
        return self.get_score_for_normalised_board(normalized_matrix)
    
    def normalize_input_to_turn_player(self, board: np.ndarray, turn_player: int) -> np.ndarray:

        return (board.astype(np.float32) * float(turn_player))

    def get_score_for_normalised_board(self, normalised_board: np.ndarray) -> float:

        assert normalised_board.shape == (8, 8), "Expected (8,8) board"
        x = torch.from_numpy(normalised_board).float().unsqueeze(0).unsqueeze(0)  # (1,1,8,8)
        x = x.to(self.device)

        with torch.no_grad():
            out = self.model(x)
            score = float(out.item() * 64)

        return score

if __name__ == "__main__":

    matrix = [
        [0,0,0,0,0,0,0,0],
        [0,0,0,0,0,0,0,0],
        [0,0,0,0,0,0,0,0],
        [0,0,0,1,-1,0,0,0],
        [0,0,0,-1,1,0,0,0],
        [0,0,0,0,0,0,0,0],
        [0,0,0,0,0,0,0,0],
        [0,0,0,0,0,0,0,0],
    ]

    analyst = OthelloBoardAnalyst()

    score = analyst.get_score_for_board_state(matrix, turn_player=1)
    print("Advantage (turn player):", score)
