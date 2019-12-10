using System;
using System.Collections.Generic;

namespace ProductsApp
{
    public class PubSub
    {

        private static PubSub _instance = null;

        

        private PubSub()
        {
            //_instance = new PubSub();
        }

        public static PubSub GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PubSub();
            }
            return _instance;
        }

        

        private Dictionary<string, IList<Action>> _subscribers = new Dictionary<string, IList<Action>>();

        public void Subscribe(string eventName, Action subscription)
        {
            if (!_subscribers.ContainsKey(eventName))
            {
                _subscribers.Add(eventName, new List<Action>());
            }
            var actions = _subscribers[eventName];
            actions.Add(subscription);
        }

        public void Publish(string eventName)
        {
            var subscriptions = this._subscribers[eventName];
            foreach(var action in subscriptions)
            {
                action();
            }
        }

    }
}
