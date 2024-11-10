namespace DogQuiz.Server.Models.Enums;

public enum QuizMode
{
    /// <summary>
    /// A fixed number of questions with no time limit.
    /// </summary>
    FixedQuestionCount,

#if false
    /// <summary>
    /// Answer as many questions as possible within a time limit.
    /// </summary>
    TimedRush,

    /// <summary>
    /// Continue until the first incorrect answer.
    /// </summary>
    SurvivalMode,

    /// <summary>
    /// Collect maximum points by answering under time pressure and through scoring bonuses.
    /// </summary>
    ScoreChallenge,

    /// <summary>
    /// Each question has a strict time limit.
    /// </summary>
    SpeedMode,

    /// <summary>
    /// Real-time competition with another player.
    /// </summary>
    MultiplayerMode,

    /// <summary>
    /// Progressively harder questions with each correct answer.
    /// </summary>
    ProgressiveMode,

    /// <summary>
    /// Adjusts difficulty based on user performance.
    /// </summary>
    AdaptiveMode
#endif
}