using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGameLib
{
    public class BowlingGame
    {
        private List<int> _rolls = new List<int>();

        public int Score()
        {
            var score = 0;
            for (var frame = 1; frame <= 10; frame++)
                score += ScoreFor(frame);

            return score;
        }

        public void Roll(int pins)
        {
            _rolls.Add(pins);
            if(FirstThrowIsAStrike()) _rolls.Add(0);
        }

        public int ScoreFor(int frame)
        {
            if (IsStrikeAt(frame)) return StrikeScoreFor(frame);

            if (IsSpareAt(frame)) return SpareScoreFor(frame);

            return OpenScoreFor(frame);
        }

        //private

        private int SpareScoreFor(int frame)
        {
            return OpenScoreFor(frame) + FirstThrowFor(NextFrame(frame));
        }

        private bool IsSpareAt(int frame)
        {
            return (OpenScoreFor(frame) == 10) && !IsStrikeAt(frame);
        }

        private int OpenScoreFor(int frame)
        {
            return FirstThrowFor(frame) + SecondThrowFor(frame);
        }

        private int SecondThrowFor(int frame)
        {
            return ScoreAtThrow(IndexFor(frame) + 1);
        }

        private int StrikeScoreFor(int frame)
        {
            //score = open_score_for(frame) + open_score_for(next_frame(frame))
    
            //if is_strike_at? next_frame(frame)
            //  score += first_throw_for(next_frame(next_frame(frame)))
            //end

            //score

            var score = OpenScoreFor(frame) + OpenScoreFor(NextFrame(frame));
            if(IsStrikeAt(NextFrame(frame)))
            {
                score += FirstThrowFor(NextFrame(NextFrame(frame)));
            }

            return score;
        }

        private int NextFrame(int frame)
        {
            return frame + 1;
        }

        private bool IsStrikeAt(int frame)
        {
            return FirstThrowFor(frame) == 10;
        }

        private int FirstThrowFor(int frame)
        {
            return ScoreAtThrow(IndexFor(frame));
        }

        private int IndexFor(int frame)
        {
            return (frame - 1) * 2;
        }

        private int ScoreAtThrow(int index)
        {
            return _rolls.Count > index ? _rolls[index] : 0;
        }

        private bool FirstThrowIsAStrike()
        {
            return IsFirstThrowInFrame() && _rolls.Last() == 10;
        }

        private bool IsFirstThrowInFrame()
        {
            return (_rolls.Count%2) == 1;
        }
    }
}
