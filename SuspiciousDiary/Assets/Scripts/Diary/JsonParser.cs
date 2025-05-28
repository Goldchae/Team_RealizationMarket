using System;
using UnityEngine;

public static class JsonParser {
    public static T[] FromJson<T>(string json) {
        string wrappedJson = "{\"pages\":" + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(wrappedJson);
        return wrapper.pages;
    }

    [Serializable]
    private class Wrapper<T> {
        public T[] pages;
    }
}