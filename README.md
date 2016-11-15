#Another EQ Log Parser? Why?#

Everquest OpenParser is intended to be used by other developers who want to create a functional application (dps tracker, audio triggers etc). 
While there are some objects in the library that provide interpretations of the log file data, they are simply included to save the developer some time for known and common Everquest events.

There are some other libraries out for parsing the EQ logs but I personally did not like the implementation strategies and lack of flexibility for the library consumer.

#I want to create an application. How do I use this library?#


### Simple: Event Wrapper ###
While less flexible than other methods this implementation of the library contains a quick way to jump in and test the library with your idea.

```c#
var log = new LogFile(pathToLog, watchFileBool, readFromBeginningBool);
           
// the subscription wrapper has events setup for all the prebuilt events in the library. Here is an example of listening to only say messages
var subscriptionWrapper = new SubscriptionWrapper(log);
           subscriptionWrapper.OnSay += Sub_OnSay;

private void Sub_OnSay(object sender, Say e)
        {
                //origin = PC , NPC, Unknown
                Debug.Print($"Say[{e.Origin}] [{e.From}] - {e.Message}");
        }
```



### Intermediate: Prebuilt Subscription ###
Slightly more flexible use of the prebuilt event subscriptions.

```c#
var log = new LogFile(pathToLog, watchFileBool, readFromBeginningBool);
           
 var saySubscription = new SaySubscription(logFile);
            saySubscription.SayReceived += Sub_OnSay;

private void Sub_OnSay(object sender, Say e)
        {
                Debug.Print($"Say[{e.Origin}] [{e.From}] - {e.Message}");
        }
```

##### How about say messages only from PC or Unknown origins? #####

```c#
var log = new LogFile(pathToLog, watchFileBool, readFromBeginningBool);
           
var saySubscription = new SaySubscription(logFile, SayOrigins.Player | SayOrigins.Unknown);
            saySubscription.SayReceived += Sub_OnSay;

private void Sub_OnSay(object sender, Say e)
        {
                Debug.Print($"Say[{e.Origin}] [{e.From}] - {e.Message}");
        }
```



### Advanced: Custom Subscription ###

It is very simple to add your own custom subsciptions which can implement a few different strategies.

**If you find yourself using a strategy and then applying additional filtering after receiving the events in your code, I recommend you review which strategy you chose to use. They are there to allow you to keep that ugly code out of the client.**

##### RegexStrategy #####
This strategy is used to check a log entry against a regex pattern and trigger an event if matched.

The [SaySubscription](https://github.com/thesmallbang/EverquestOpenParser/blob/master/OpenParser/Subscribers/SaySubscription.cs) uses the RegexStrategy and is a very simple example of how to create your own subscriptions.


##### RegexWithInverseStrategy #####
This strategy inherits the RegexStrategy allowing for 2 regex parameters. The first must match and the second must not match in order for the event to trigger. This is useful when you cannot implement a perfect regex pattern for the match but have another pattern you can use to validate it is not a false positive.

While no prebuilt subscribers used this strategy a sample (useless) scenario could be like the following:

1) You want to match any log entry that contains the word platinum.

2) You do not want matches that came from tells


##### RegexWithCheckStrategy #####
This strategy allows for normal RegexStrategy functionality with one key difference. An additional check against the LogEntry data can be added before deciding if the event should trigger.

Here is an example that would trigger on all Say messages unless the message contained the word platinum or the person's name was platinum.
```c#
Subscriber = new Subscriber<Say>(logFile, new RegexWithCheckStrategy<Say>(Chat.SayRegex,o=> !o.Text.ToLower().Contains("platinum".AddSpaces()), HandleMatches));
```







