using System;
using Avalonia.Controls;
using System.Collections.Generic;
using System.Text;

namespace PO_WIZ__sekwencer.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();

    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string text = tb.Text;
        if (string.IsNullOrEmpty(text))
        {
            return;
        }
        else
        {
            ProcessText(text);
        }
    }
    private void ProcessText(string text)
    {
        List<string> listSeq = new List<string>();  

        for(int i = 0; i < text.Length; i+=4)
        {
           string seq = text.Substring(i, Math.Min(4, text.Length - i));
           listSeq.Add(seq);
        }

        Dictionary<string, int> stats = new Dictionary<string, int>();

        foreach (string seq in listSeq)
        {
            if (!stats.ContainsKey(seq))
            {
                stats.Add(seq, 1);
            }
            else
            {
                stats[seq]++;
            }
        }

        StringBuilder sb = new StringBuilder();
        foreach (var entry in stats)
        {
            sb.AppendLine($"Sekwencja: {entry.Key}, Ilość: {entry.Value}");
        }

        OutputBox.Text = sb.ToString();
    }
}
