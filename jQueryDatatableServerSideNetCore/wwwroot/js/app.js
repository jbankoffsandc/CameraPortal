$(document).ready(function () {
    PopulateCameras();
   
});

function PopulateCameras() {

    var table = $('#AppDataTable').DataTable({
        ajax: {
            url: "/home/getdataset",
            dataSrc: 'data'
        },
        
        fixedHeader: true,
        select: true,
        searching: false,
        paging: false,
        "columns": [
            { "data": "department", "title": "Dept" },
            { "data": "location", "title": "Location" },
            { "data": "mac_address", "title": "History" }
        ]
        

    });

    
    

   
    table.on('select', function (e, dt, type, indexes) {
        table[type](indexes).nodes().to$().toggleClass('selectedCamera');
        var object = $('#' + indexes);
        if (object.length > 0) {
            $('#' + indexes).remove();
        }
        else {

            //    alert(testValue + " " + table.rows( { selected: true } ).data()[0]['ip_address'] + " " +  table.rows( { selected: true } ).data()[0]['dept'] + " " + table.rows( { selected: true } ).data()[0]['location'] + table.rows( { selected: true } ).data()[0]['hyperlink'] + " "  + table.rows( { selected: true } ).data()[0]['camera_id']   );
            $("<div class='cameraWindow' id='" + indexes + "'><label for='fp_embed_player' style='color: navy; font-size: 15px;'>" + "Camera " + table.rows({ selected: true }).data()[0]['camera_id'] + " " + table.rows({ selected: true }).data()[0]['department'] + " " + table.rows({ selected: true }).data()[0]['location'] + "</label><br><div height='80%' width='80%'><iframe id='fp_embed_player' width='100%' height='70%'  src='https://10.20.52.5:8888/embed_player?urlServer=wss://10.20.52.5:8443&streamName=rtsp://" + table.rows({ selected: true }).data()[0]['ip_address'] + "/live/1/h264.sdp&autoplay=true&mediaProviders=WebRTC,Flash,MSE,WSPlayer' marginwidth='0' marginheight='0' frameborder='0' width='100%' height='100%' scrolling='no' allowfullscreen='allowfullscreen'>test comment</iframe></div></div>") // append new `<div>` to it
                .appendTo("#existingDiv");
        }
    });

}