(function () {

    'use strict';

    angular.module('fasterAdministration').controller('VideoCtrl', VideoCtrl);

    VideoCtrl.$inject = ['$location', '$sce', '$timeout', '$interval', 'VideoFactory'];

    function VideoCtrl($location, $sce, $timeout, $interval, VideoFactory) {

        var vm = this;

        vm.state = null;
        vm.API = null;
        vm.currentVideo = 0;

        function onPlayerReady(API) {
            console.log(API);
            alert(API);
            vm.API = API;
        };

        vm.videos = [
            {
                sources: [
                    { src: $sce.trustAsResourceUrl("http://static.videogular.com/assets/videos/videogular.mp4"), type: "video/mp4" },
                    { src: $sce.trustAsResourceUrl("http://static.videogular.com/assets/videos/videogular.webm"), type: "video/webm" },
                    { src: $sce.trustAsResourceUrl("http://static.videogular.com/assets/videos/videogular.ogg"), type: "video/ogg" }
                ]
            },
            {
                sources: [
                    { src: $sce.trustAsResourceUrl("http://static.videogular.com/assets/videos/big_buck_bunny_720p_h264.mov"), type: "video/mp4" },
                    { src: $sce.trustAsResourceUrl("http://static.videogular.com/assets/videos/big_buck_bunny_720p_stereo.ogg"), type: "video/ogg" }
                ]
            }
        ];
        vm.config = {
            preload: "none",
            autoHide: false,
            autoHideTime: 3000,
            autoPlay: true,
            sources: vm.videos[0].sources,
            theme: {
                url: "http://www.videogular.com/styles/themes/default/latest/videogular.css"
            },
            plugins: {
                poster: "http://www.videogular.com/assets/images/videogular.png"
            }
        };


        vm.onCompleteVideo = onCompleteVideo;
        vm.onCompleteVideo = onCompleteVideo;
        vm.setVideo = setVideo;
        vm.onPlayerReady = onPlayerReady;






        function onCompleteVideo() {
            vm.isCompleted = true;
            vm.currentVideo++;

            if (vm.currentVideo >= vm.videos.length) vm.currentVideo = 0;

            vm.setVideo(vm.currentVideo);
        };


        function setVideo(index) {
            vm.API.stop();
            vm.currentVideo = index;
            vm.config.sources = vm.videos[index].sources;
            $timeout(vm.API.play.bind(vm.API), 100);
        };

        activate();


        function activate() {

        }

        function callAtInterval(item) {
            toastr.warning("URL: " + item.url, '<strong>URL de Video</strong>');;
        }

        function getVideos() {
            VideoFactory.get()
                .success(success)
                .catch(fail);

            function success(response) {
                console.log(response);
                vm.video = response;



                //vm.video.forEach(function (item) {
                //$interval(callAtInterval(item), 5000);
                //})

            }
            function fail(error) {

                toastr.warning('<strong>Falha ao recuperar dados!</strong>');

            }
        }
    }
})();