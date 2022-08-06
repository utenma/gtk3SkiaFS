namespace gtk3SkiaFS

open Gtk
open SkiaSharp
open SkiaSharp.Views.Gtk
open System

module Program =

    [<EntryPoint; STAThread>]
    let main argv =
        Application.Init()

        let app = new Application("org.gtk3SkiaFS.gtk3SkiaFS", GLib.ApplicationFlags.None)
        app.Register(GLib.Cancellable.Current) |> ignore

        let win = new Window(WindowType.Toplevel)

        win.Title <- "SkiaSharp on .NET Core with GTK#"
        win.WindowPosition <- WindowPosition.CenterOnParent
        win.DefaultWidth <- 640
        win.DefaultHeight <- 480

        win.DeleteEvent.Add(fun e -> Application.Quit())

        let skiaDraw = new SKDrawingArea()

        skiaDraw.PaintSurface.Add (fun e ->
            let canvas = e.Surface.Canvas
            let info = e.Info

            canvas.Clear(SKColors.Azure)

            let paint =
                new SKPaint(
                    Color = SKColors.SlateBlue,
                    IsAntialias = true,
                    Style = SKPaintStyle.Fill,
                    TextAlign = SKTextAlign.Center,
                    TextSize = 32f
                )

            let skPoint =
                SKPoint(x = float32 (info.Width / 2), y = float32 ((info.Height + int (paint.TextSize)) / 2))

            canvas.DrawText("SkiaSharp on GTK# on .NET Core", skPoint, paint))

        win.Add(skiaDraw)
        win.Child.ShowAll()
        win.Show()
        app.AddWindow(win)
        win.Show()
        Application.Run()
        0
