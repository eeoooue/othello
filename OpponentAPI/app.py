
from flask import Flask, request, jsonify
from flask_cors import CORS
from othello_board_analyst import OthelloBoardAnalyst

app = Flask(__name__)
CORS(app)

analyst = OthelloBoardAnalyst()

@app.route("/evaluate_board", methods=["POST"])
def evaluate_board():
    data = request.get_json()

    board_list = data.get("board")
    player = data.get("player")

    if not board_list or len(board_list) != 8 or any(len(row) != 8 for row in board_list):
        return jsonify({"error": "Invalid board format. Must be 8x8 grid."}), 400
    if player not in [-1, 1]:
        return jsonify({"error": "Player must be 1 (black) or -1 (white)."}), 400

    score = analyst.get_score_for_board_state(board_list, player)
    return str(score)

if __name__ == "__main__":
    
    app.run(host="0.0.0.0", port=5000)
