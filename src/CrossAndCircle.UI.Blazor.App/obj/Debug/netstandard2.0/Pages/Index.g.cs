#pragma checksum "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2f183b78d7ec9ab85821077d91b6d35a3b687831"
// <auto-generated/>
#pragma warning disable 1591
namespace CrossAndCircle.UI.Blazor.App.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Blazor;
    using Microsoft.AspNetCore.Blazor.Components;
    using System.Net.Http;
    using Microsoft.AspNetCore.Blazor.Layouts;
    using Microsoft.AspNetCore.Blazor.Routing;
    using Microsoft.JSInterop;
    using CrossAndCircle.UI.Blazor.App;
    using CrossAndCircle.UI.Blazor.App.Shared;
    using GameEngine;
    [Microsoft.AspNetCore.Blazor.Layouts.LayoutAttribute(typeof(MainLayout))]

    [Microsoft.AspNetCore.Blazor.Components.RouteAttribute("/")]
    public class Index : Microsoft.AspNetCore.Blazor.Components.BlazorComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Blazor.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            builder.AddMarkupContent(0, "<h1>CROSS AND CIRCLE GAME</h1>\n\n<br>\n\n\n\n\n");
            builder.OpenElement(1, "button");
            builder.AddAttribute(2, "class", "btn btn-primary");
            builder.AddAttribute(3, "onclick", Microsoft.AspNetCore.Blazor.Components.BindMethods.GetEventHandlerValue<Microsoft.AspNetCore.Blazor.UIMouseEventArgs>(StartNewGame_vsComputer));
            builder.AddContent(4, "PLAYER vs COMPUTER");
            builder.CloseElement();
            builder.AddContent(5, "\n");
            builder.OpenElement(6, "button");
            builder.AddAttribute(7, "class", "btn btn-primary");
            builder.AddAttribute(8, "onclick", Microsoft.AspNetCore.Blazor.Components.BindMethods.GetEventHandlerValue<Microsoft.AspNetCore.Blazor.UIMouseEventArgs>(StartNewGame_1vs1));
            builder.AddContent(9, "PLAYER vs PLAYER");
            builder.CloseElement();
            builder.AddMarkupContent(10, "\n\n<br><br><br>\n\n\n\n\n");
            builder.OpenElement(11, "div");
            builder.AddContent(12, "\n");
#line 19 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
     if (game != null && game.Current != null)
    {
        

#line default
#line hidden
#line 21 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
         for (int i = 0; i < game.Current.Rows.Length; i++)
        {

#line default
#line hidden
            builder.AddMarkupContent(13, "            <br>\n");
#line 24 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
             for (int j = 0; j < game.Current.Cols.Length; j++)
            {
                var copyi = i;
                var copyj = j;


#line default
#line hidden
            builder.AddContent(14, "                ");
            builder.OpenElement(15, "button");
            builder.AddAttribute(16, "onclick", Microsoft.AspNetCore.Blazor.Components.BindMethods.GetEventHandlerValue<Microsoft.AspNetCore.Blazor.UIMouseEventArgs>(() => SetPosition(copyi, copyj)));
            builder.AddAttribute(17, "class", "btn btn-secondary");
            builder.AddAttribute(18, "style", "width: 50px; height:50px; margin:5px");
            builder.AddMarkupContent(19, "\n                    \n                    \n                    \n");
#line 33 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
                     if (game.Current[i, j] == GameBoard.Player.Circle)
                    {
                        if (IsWinningPosition(copyi, copyj))
                        {

#line default
#line hidden
            builder.AddContent(20, "                            ");
            builder.AddMarkupContent(21, "<h1 style=\"font-size:40px; color:red; margin:-5px 0px 0px -4px\">O</h1>\n");
#line 38 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            builder.AddContent(22, "                            ");
            builder.AddMarkupContent(23, "<h1 style=\"font-size:40px; margin:-5px 0px 0px -4px\">O</h1>\n");
#line 42 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
                        }

                    }

#line default
#line hidden
            builder.AddMarkupContent(24, "                    \n                    \n                    \n");
#line 48 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
                     if (game.Current[i, j] == GameBoard.Player.Cross)
                    {
                        if (IsWinningPosition(copyi, copyj))
                        {

#line default
#line hidden
            builder.AddContent(25, "                            ");
            builder.AddMarkupContent(26, "<h1 style=\"font-size:40px; color:red; margin:-4px 0px 0px -3px\">X</h1>\n");
#line 53 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            builder.AddContent(27, "                            ");
            builder.AddMarkupContent(28, "<h1 style=\"font-size:40px; margin:-4px 0px 0px -3px\">X</h1>\n");
#line 57 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
                        }

                    }

#line default
#line hidden
            builder.AddContent(29, "                ");
            builder.CloseElement();
            builder.AddContent(30, "\n");
#line 61 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
            }

#line default
#line hidden
#line 61 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
             
        }

#line default
#line hidden
#line 62 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
         
    }

#line default
#line hidden
            builder.CloseElement();
            builder.AddMarkupContent(31, "\n\n<br>\n\n\n\n\n");
            builder.OpenElement(32, "div");
            builder.AddContent(33, "\n");
#line 72 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
     if (circleWinsGame)
    {

#line default
#line hidden
            builder.AddContent(34, "        ");
            builder.AddMarkupContent(35, "<h2>Congratulations! Circle Wins the game! :)</h2>\n");
#line 75 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
    }

#line default
#line hidden
            builder.AddContent(36, "    ");
#line 76 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
     if (crossWinsGame)
    {

#line default
#line hidden
            builder.AddContent(37, "        ");
            builder.AddMarkupContent(38, "<h2>Congratulations! Cross Wins the game! :)</h2>\n");
#line 79 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
    }

#line default
#line hidden
            builder.AddContent(39, "    ");
#line 80 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
     if (gameEndsWithoutWinner)
    {

#line default
#line hidden
            builder.AddContent(40, "        ");
            builder.AddMarkupContent(41, "<h2>Tie! There is no winner :(</h2>\n");
#line 83 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
    }

#line default
#line hidden
            builder.CloseElement();
        }
        #pragma warning restore 1998
#line 90 "C:\CODE\GIT-SEDY\DotNet\CrossAndCircleGame\CrossAndCircle.UI.Blazor.App\Pages\Index.cshtml"
            

    private WebGame game;
    private GameBoard.Player p1Id = GameBoard.Player.Circle;
    private GameBoard.Player p2Id = GameBoard.Player.Cross;
    private bool circleWinsGame;
    private bool crossWinsGame;
    private bool gameEndsWithoutWinner;

    private void StartNewGame_vsComputer()
    {
        CreateGame();
        this.game.Start(p1Id);
        ClearFlags();
    }

    private void StartNewGame_1vs1()
    {
        CreateGame();
        this.game.Start(p1Id, p2Id);
        ClearFlags();
    }

    private void CreateGame()
    {
        if (this.game == null)
        {
            this.game = new WebGame();
            this.game.StateChanged += OnStateChanged;
        }
    }

    private void ClearFlags()
    {
        this.circleWinsGame = false;
        this.crossWinsGame = false;
        this.gameEndsWithoutWinner = false;
    }

    private void OnStateChanged(object sender, EventArgs ea)
    {
        if (this.game.EndStatus.HasValue && this.game.EndStatus.Value == EndStatus.CircleWins)
        {
            circleWinsGame = true;
        }
        if (this.game.EndStatus.HasValue && this.game.EndStatus.Value == EndStatus.CrossWins)
        {
            crossWinsGame = true;
        }
        if (this.game.EndStatus.HasValue && this.game.EndStatus.Value == EndStatus.Draw)
        {
            gameEndsWithoutWinner = true;
        }
    }

    void SetPosition(int i, int j)
    {
        this.game.Move(i, j);
    }
    private bool IsWinningPosition(int x, int y)
    {
        return this.game.WinningPositions.Any(w => w.X == x && w.Y == y);
    }

#line default
#line hidden
    }
}
#pragma warning restore 1591