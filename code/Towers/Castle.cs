﻿using System;
using Sandbox;

public partial class Castle : TowerBase
{
	public override string TowerName => "Castle";
	public override string TowerDesc => "Home base, you should defend this";
	public override string TowerModel => "models/towers/castle.vmdl";
/*	public int AttackDamage => -1;
	public float AttackCooldown => -1;*/
	public override int Cost => -1;
	public override int MaxTier => 0;

	public int CastleHealth = 100;

	public enum CastleTeam
	{
		Unknown,
		Blue,
		Red
	}

	public CastleTeam TeamCastle { get; set; } = CastleTeam.Unknown;
	public override void Spawn()
	{
		base.Spawn();
		Health = CastleHealth;
	}

	public override void SimulateTower()
	{

	}

	public void Destroyed()
	{
		if ( TDGame.Current.GameType == TDGame.GamemodeType.Competitive )
		{
			if ( Name == "blue_castle" || TeamCastle == CastleTeam.Blue )
				TDGame.Current.AnnounceWinningTeam( "Red" );
			else if ( Name == "red_castle" || TeamCastle == CastleTeam.Red )
				TDGame.Current.AnnounceWinningTeam( "Blue" );
		}
		else
		{
			TDGame.Current.EndGame();
		}

		Delete();
	}

	public override void TakeDamage( DamageInfo info )
	{
		base.TakeDamage( info );
	}

	public override void OnKilled()
	{
	}
}
