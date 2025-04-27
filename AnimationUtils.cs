using System;
using System.Diagnostics;
using System.Threading; 
using static System.Console;
using AsciiArtUtil;

public static class AnimationUtils
{
  public static void Animate(string frame, int changeFrameLength = 0)
  {
    frame = AsciiArt.GetAsciiImage(frame, 231, 76);

    SetCursorPosition(0, 0);

    File.WriteAllText("TextFile.txt", frame);

    Write(frame);

    Thread.Sleep(changeFrameLength);
  } 
}