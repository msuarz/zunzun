using System;
using FluentSpec;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zunzun.App.Presenters;
using Zunzun.Domain.Classes;
using ObjectFactory=Zunzun.Domain.ObjectFactory;

namespace Zunzun.Specs {
    [TestClass]
    public class when_updating_Status : BehaviorOf<StatusPresenter> {
        [TestMethod]
        public void should_request_a_Status_Update() {
            var SuperCoolTweet = new TweetClass {Content = new Guid().ToString()};

            When.Update(SuperCoolTweet);
            Then.TweetService.Should().UpdateStatus(SuperCoolTweet);
        }

        [TestMethod]
        public void should_create_a_Tweet_based_on_view() {
        
            Given.View.UpdateText = "very cool";
            When.Update();
            Then.TweetService.Should().UpdateStatus(ObjectFactory.NewTweet("very cool"));
        }

        [TestMethod]
        public void should_not_send_empty_updates() {
        
            Given.View.UpdateText = string.Empty;
            When.Update();
            Then.TweetService.ShouldNot().IgnoringArgs().UpdateStatus(null);
        }

        [TestMethod]
        public void should_clear_view_after_Updating() {
        
            Given.View.UpdateText = "Content";
            When.Update();
            Should.View.UpdateText = string.Empty;
        }

        [TestMethod]
        public void should_toggle_visibility() {
        
            Given.View.IsUpdateVisible = true;
            
            When.ToggleUpdateVisibility();
            Then.View.IsUpdateVisible.ShouldBeFalse();
            
            When.ToggleUpdateVisibility();
            Then.View.IsUpdateVisible.ShouldBeTrue();
        }
    }
}