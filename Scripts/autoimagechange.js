var mygallery = new fadeSlideShow({
    wrapperid: "fadeshow1", //ID of blank DIV on page to house Slideshow
    dimensions: [350, 250], //width/height of gallery in pixels. Should reflect dimensions of largest image
    imagearray: [
		["Images/a.jpeg", "", "", ""],
		["Images/b.jpeg", "", "", ""],
        ["Images/c.jpeg", "", "", ""],
        ["Images/e.jpeg", "", "", ""]

    //<--no trailing comma after very last image element!
	],
    displaymode: { type: 'auto', pause: 2500, cycles: 0, wraparound: false },
    persist: false, //remember last viewed slide and recall within same session?
    fadeduration: 500, //transition duration (milliseconds)
    descreveal: "always",
    togglerid: ""
})



