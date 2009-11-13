using System;
using System.Linq;
using System.Threading;
using FluentSpec;
using Zunzun.App.Presenters;
using Zunzun.App.Views;
using Zunzun.Domain;
using Zunzun.Specs.Helpers;

namespace Zunzun.Specs.Fixtures {

    public class RefreshingTweets : Spec {
        
        readonly HomePresenter HomePresenter;
        readonly HomeView HomeView;

        readonly Tweet Tweet = Actors.UniqueTweet;
        
        public RefreshingTweets() {
            HomeView = Create.TestObjectFor<HomeView>();
            HomePresenter = PresenterFactory.NewHomePresenter(HomeView);
        }

        protected override void SetUpSteps() {

            Given("the Refresh Cycle is {0} seconds", RefreshCycle => 
                App.Settings.DefaultRefreshCycle = Convert.ToInt32(RefreshCycle) 
            );

            And("Home is shown", () => HomePresenter.Load()); 
            
            When("Status is updated", () => 
                HomePresenter.TweetService.UpdateStatus(Tweet)
            );
            
            And("{0} seconds have passed", WaitTime => 
                Thread.Sleep(Convert.ToInt32(WaitTime))
            );
            
            Then("Home should contain the Tweet", () => 
                HomeView.Tweets.ToList().ShouldContain(Tweet)
            );
        }
    }
}