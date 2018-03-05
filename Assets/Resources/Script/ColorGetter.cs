using UnityEngine;

public class ColorGetter : MonoBehaviour
{
    /// <summary>
    /// 指定された文字列を Color 型に変換できる場合 true を返します
    /// </summary>
    public bool IsColor(string htmlString)
    {
        Color color;
        return ColorUtility.TryParseHtmlString(htmlString, out color);
    }

    /// <summary>
    /// 指定された文字列を Color 型に変換します
    /// </summary>
    public Color ToColor(string htmlString)
    {
        Color color;
        ColorUtility.TryParseHtmlString(htmlString, out color);
        return color;
    }

    /// <summary>
    /// 指定された Color 型を文字列に変換します
    /// </summary>
    public string ToColorString (Color Col)
    {
        string ColorString=ColorUtility.ToHtmlStringRGBA(Col);
        return ColorString;
    }



    /// <summary>
    /// <para>指定された文字列を Color 型に変換します</para>
    /// <para>変換できなかった場合デフォルト値を返します</para>
    /// </summary>
    public Color ToColorOrDefault(string htmlString, Color defaultValue = default(Color))
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(htmlString, out color))
        {
            return color;
        }
        return defaultValue;
    }

    /// <summary>
    /// <para>指定された文字列を Color 型に変換します</para>
    /// <para>変換できなかった場合 null を返します</para>
    /// </summary>
    public Color? ToColorOrNull(string htmlString)
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(htmlString, out color))
        {
            return color;
        }
        return null;
    }
}