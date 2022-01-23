// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(".fancybutton").on("click", (e) => {
    console.log("got here");
    console.log(e.target.dataset);
    console.log(generateText(10));

    const model =
    {
        Author: generateText(7),
        Text: generateText(20),
        MovieID: e.target.dataset.movieid



    };
    console.log(JSON.stringify(model));
    fetch('/Movie/AddComment',
        {
            method: "POST",
            mode: 'cors',
            body: JSON.stringify(model),
            headers: {
                'Accept': 'application/json, text/plain, */*',
                'Content-Type': 'application/json'
            }
        }
    )
        .then(function (res) {
            console.log(res)
            return res.text();

        })
        .then((html) => {
            //console.log(html);
            $("#" + model.MovieID).empty();
            $('#' + model.MovieID).html(html);
        });

    //post a name, comment to API return object and popuate list post back
});

function generateText(length) {
    var result = '';
    var characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    var charactersLength = characters.length;
    for (var i = 0; i < length; i++) {
        result += characters.charAt(Math.floor(Math.random() *
            charactersLength));
    }
    return result;
}


