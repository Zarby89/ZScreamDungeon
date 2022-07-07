namespace ZeldaFullEditor.ALTTP.GameData;

public enum GameState
{
	RainState = 0,
	UncleState = 1,
	RescueState = 2,
	AgaState = 3,
}

public sealed class GameStateInfo
{
	public string Name { get; }
	public GameState State { get; }

	private GameStateInfo(string name, GameState state)
	{
		Name = name;
		State = state;
	}

	internal static readonly ImmutableArray<GameStateInfo> ListOf = new GameStateInfo[]
	{
		new("Rain state (0/1)", GameState.RainState),
		new("Zelda rescued (2)", GameState.RescueState),
		new("Agahnim defeated (3)", GameState.AgaState),
	}.ToImmutableArray();

	public override string ToString()
	{
		return Name;
	}
}
