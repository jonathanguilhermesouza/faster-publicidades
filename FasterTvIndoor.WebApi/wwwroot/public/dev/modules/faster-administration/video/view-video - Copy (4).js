﻿(function () {

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
            vm.API = API;
            vm.API.toggleFullScreen();

        };


        vm.videoteste = [
                    { src: "video2.mp4", type: "video/mp4" }
        ]
        
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
            vm.isCompleted = true;
            vm.currentVideo++;

            if (vm.currentVideo >= vm.jonathanvideos.length) vm.currentVideo = 0;

            vm.setVideo(vm.currentVideo);
        };


        function setVideo(index) {
            vm.API.stop();
            vm.currentVideo = index;
            selectVideo(index);
            $timeout(vm.API.play.bind(vm.API), 100);
        };

        function selectVideo(index) {
            vm.config.sources = vm.jonathanvideos[index];
            console.log(index);
            console.log(vm.jonathanvideos[index]);
            console.log(vm.config.sources.src);

        }


        function getVideos() {
            VideoFactory.get()
                .success(success)
                .catch(fail);

            function success(response) {
                vm.video = response;

                console.log('vm.video');
                console.log(vm.video);

                for (var i = 0; i < vm.video.length; i++) {
                    
                    vm.jonathanvideos.push([{ src: $sce.trustAsResourceUrl(vm.video[i].src), type: 'video/mp4' }]);
                    console.log(vm.jonathanvideos);
                    alert('t');
                }
                vm.jonathanvideos.splice(0, 1)

                //vm.video.forEach(function (item) {
                //    vm.jonathan.src = $sce.trustAsResourceUrl(item.src);
                //    vm.jonathan.type = 'video/mp4';
                //    vm.jonathanvideos.push(vm.jonathan);
                //    //vm.videos[vm.video.indexOf(item)].sources.src = $sce.trustAsResourceUrl(item.src);
                //    //vm.videoteste[vm.video.indexOf(item)].sources.src = $sce.trustAsResourceUrl(item.src);
                //    //alert(vm.videos[vm.video.indexOf(item)].sources.src);
                //    //$interval(callAtInterval(item), 5000);
                //    console.log(item);
                //    console.log(vm.jonathan);
                //})

                console.log('getvideos');
                console.log(vm.jonathanvideos);

            }
            function fail(error) {

                toastr.warning('<strong>Falha ao recuperar dados!</strong>');

            }
        }
    }
})();