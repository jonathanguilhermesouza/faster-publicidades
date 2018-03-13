(function () {

    'use strict';

    angular.module('fasterAdministration').controller('VideoCtrl', VideoCtrl);

    VideoCtrl.$inject = ['$location', '$sce', '$timeout', '$interval', 'VideoFactory'];

    function VideoCtrl($location, $sce, $timeout, $interval, VideoFactory) {

        var vm = this;

        vm.state = null;
        vm.API = null;
        vm.currentVideo = 0;

        vm.jonathanvideos = [{
            src: '',
            type: ''
        }];
        vm.jonathan = {
            src: '',
            type: ''
        };


        getVideos();

        

        function onPlayerReady(API) {
            console.log(API);
            vm.API = API;
            vm.API.toggleFullScreen();

        };


        vm.videoteste = [
                    { src: $sce.trustAsResourceUrl("video2.mp4"), type: "video/mp4" }
        ]

        console.log(vm.videoteste);

        vm.videos = [
            {
                sources: [
                    { src: $sce.trustAsResourceUrl("video1.mp4"), type: "video/mp4" }
                    //,{ src: $sce.trustAsResourceUrl("http://static.videogular.com/assets/videos/videogular.webm"), type: "video/webm" },
                    //{ src: $sce.trustAsResourceUrl("http://static.videogular.com/assets/videos/videogular.ogg"), type: "video/ogg" }
                ]
            },
            {
                sources: [
                    { src: $sce.trustAsResourceUrl("video2.mp4"), type: "video/mp4" }

                    //{ src: $sce.trustAsResourceUrl("http://static.videogular.com/assets/videos/big_buck_bunny_720p_stereo.ogg"), type: "video/ogg" }
                ]
            }
        ];

        getVideos();

        vm.config = {
            preload: "true",
            autoHide: false,
            loop: false,
            autoHideTime: 3000,
            autohideCursor: true,
            autohideCursorTime: 3000,
            autoPlay: true,
            sources: vm.videoteste,
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
            //uptadeListVideo();
            vm.isCompleted = true;
            vm.currentVideo++;

            if (vm.currentVideo >= vm.jonathanvideos.length) vm.currentVideo = 0;

            vm.setVideo(vm.currentVideo);
        };


        function setVideo(index) {
            vm.API.stop();
            vm.currentVideo = index;
            selectVideo(index);

            
            console.log(vm.videoteste);
            $timeout(vm.API.play.bind(vm.API), 100);
        };

        function selectVideo(index) {
            alert(index);
            vm.videoteste = vm.jonathanvideos[index];
            vm.config.sources = vm.videoteste;
            console.log(vm.videoteste.src);

        }

        activate();


        function activate() {
            console.log(vm.videos[0].sources);
            //getVideos();
            //console.log(vm.videos);
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


                vm.video.forEach(function (item) {
                    vm.jonathan.src = $sce.trustAsResourceUrl(item.src);
                    vm.jonathan.type = 'video/mp4';
                    vm.jonathanvideos.push(vm.jonathan);
                    //vm.videos[vm.video.indexOf(item)].sources.src = $sce.trustAsResourceUrl(item.src);
                    //vm.videoteste[vm.video.indexOf(item)].sources.src = $sce.trustAsResourceUrl(item.src);
                    //alert(vm.videos[vm.video.indexOf(item)].sources.src);
                    //$interval(callAtInterval(item), 5000);
                })

                vm.config.sources = vm.videos;
                console.log('getvideos');
                console.log(vm.jonathanvideos);

            }
            function fail(error) {

                toastr.warning('<strong>Falha ao recuperar dados!</strong>');

            }
        }
    }
})();