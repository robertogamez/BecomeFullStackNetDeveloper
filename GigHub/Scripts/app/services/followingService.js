var FollowingService = function () {

    var createFollowing = function (followeeId, done, fail) {
        $.post('/api/followings', { followeeId: followeeId })
            .then(done, fail);
    }

    var deleteFollowing = function (followeeId, done, fail) {
        $.ajax({
            url: '/api/followings/' + followeeId,
            method: 'delete'
        }).then(done, fail);
    }

    return {
        createFollowing: createFollowing,
        deleteFollowing: deleteFollowing
    }

}();