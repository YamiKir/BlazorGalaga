using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.WebGL;
using BlazorGalaga.Interfaces;
using BlazorGalaga.Models;
using BlazorGalaga.Models.Paths;
using BlazorGalaga.Models.Paths.Challenges.Challenge3;
using BlazorGalaga.Models.Paths.Intros;
using BlazorGalaga.Services;
using BlazorGalaga.Static;
using BlazorGalaga.Static.GameServiceHelpers;
using BlazorGalaga.Static.Levels;
using BlazorGalaganimatable.Models.Paths;
using static BlazorGalaga.Pages.Index;
public class AIController
{
    private const int ScreenLeftBoundary = 0;
    private const int ScreenRightBoundary = 800; // Adjust for your screen size

    public string DecideAction(GameState state)
    {
        // Debugging: Print current game state
        Console.WriteLine($"PlayerPosition: {state.PlayerPosition}");
        Console.WriteLine($"BulletPositions: {string.Join(", ", state.BulletPositions)}");
        Console.WriteLine($"EnemyPositions: {string.Join(", ", state.EnemyPositions)}");

        // Dodge bullets logic
        var imminentBullet = state.BulletPositions
            .Where(b =>
                Math.Abs(b.X - state.PlayerPosition.X) < 50 && // Close horizontally
                b.Y > state.PlayerPosition.Y &&               // Bullet is below the player
                b.Y - state.PlayerPosition.Y < 100)           // Bullet is approaching
            .OrderBy(b => Math.Abs(b.X - state.PlayerPosition.X)) // Closest bullet horizontally
            .FirstOrDefault();

        if (imminentBullet != null)
        {
            // Dodge bullets safely
            if (imminentBullet.X < state.PlayerPosition.X && state.PlayerPosition.X < ScreenRightBoundary - 10)
            {
                Console.WriteLine("Action: MOVE_RIGHT (Dodge)");
                return "MOVE_RIGHT";
            }
            else if (imminentBullet.X > state.PlayerPosition.X && state.PlayerPosition.X > ScreenLeftBoundary + 10)
            {
                Console.WriteLine("Action: MOVE_LEFT (Dodge)");
                return "MOVE_LEFT";
            }
        }

        // Shoot if aligned with an enemy
        if (state.EnemyPositions.Any(e => Math.Abs(e.X - state.PlayerPosition.X) < 5))
        {
            Console.WriteLine("Action: SHOOT");
            return "SHOOT";
        }

        // Default to no movement
        return ""; // Prevent constant movement
    }
}
