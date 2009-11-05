using FluentSpec;
using Zunzun.App.Presenters;
using Zunzun.App.Views;
using Zunzun.Domain;
using Zunzun.Specs.Helpers;

namespace Zunzun.Specs.Fixtures {

    public class UpdateStatus : Spec {

        readonly TweetService TweetService;
        readonly StatusPresenter StatusPresenter;
        readonly StatusView StatusView;
        private Tweet tweet;

        public UpdateStatus() {
            StatusView = Create.TestObjectFor<StatusView>();
            StatusPresenter = PresenterFactory.NewStatusPresenter(StatusView);
            TweetService = StatusPresenter.TweetService;
        }

        protected override void SetUpSteps() {
        
            When["Status is updated"] = () => {
                tweet = Actors.SuperCoolTweet;
                StatusPresenter.Update(tweet);
            };

            Then["Home should contain the Tweet"] = () => {
                TweetService.Tweets.ShouldContain(tweet);
            };
        }
    }
}