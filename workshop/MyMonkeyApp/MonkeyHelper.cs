using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// 원숭이 데이터 관리를 위한 정적 헬퍼 클래스입니다.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey> monkeys = new();
    private static int randomPickCount = 0;
    private static readonly object lockObj = new();

    /// <summary>
    /// MCP 서버에서 원숭이 데이터를 비동기로 불러옵니다.
    /// </summary>
    public static async Task LoadMonkeysAsync(Func<Task<List<Monkey>>> fetcher)
    {
        var data = await fetcher();
        lock (lockObj)
        {
            monkeys = data;
        }
    }

    /// <summary>
    /// 모든 원숭이 목록을 반환합니다.
    /// </summary>
    public static List<Monkey> GetMonkeys()
    {
        lock (lockObj)
        {
            return monkeys.ToList();
        }
    }

    /// <summary>
    /// 이름으로 원숭이 정보를 반환합니다.
    /// </summary>
    public static Monkey? GetMonkeyByName(string name)
    {
        lock (lockObj)
        {
            return monkeys.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }

    /// <summary>
    /// 무작위 원숭이를 반환하고, 호출 횟수를 추적합니다.
    /// </summary>
    public static Monkey? GetRandomMonkey()
    {
        lock (lockObj)
        {
            if (monkeys.Count == 0) return null;
            randomPickCount++;
            var rand = new Random();
            return monkeys[rand.Next(monkeys.Count)];
        }
    }

    /// <summary>
    /// 무작위 선택 호출 횟수를 반환합니다.
    /// </summary>
    public static int GetRandomPickCount()
    {
        lock (lockObj)
        {
            return randomPickCount;
        }
    }
}
