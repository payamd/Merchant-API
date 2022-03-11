using Merchant_API.models;

namespace Merchant_API.services;

public class ShopItemService{

    /// ctor
    public ShopItemService()
    {
        
    }


///Default Values
    public static List<ShopItem> ShopItems= new List<ShopItem> () {
        new ShopItem(1, "LG 4K UltraHD HDR LED Smart TV - UP7100", "Put your entertainment on full display with LG's UP7100 UHD TV that is engineered to enhance color, contrast, clarity and detail.","Put your entertainment on full display with LG's UP7100 UHD TV that is engineered to enhance color, contrast, clarity and detail. This smart TV also provides compatibility with Google Home, Alexa and Apple HomeKit for convenient control of your entertainment experience.","https://i5.walmartimages.ca/images/Thumbnails/270/845/6000203270845.jpg","$999","Black","TV", "10"),
        new ShopItem(2, "RCA 24-INCH ROKU SMART TV", "xperience everything that TV has to offer with this 24-inch LED smart TV from RCA.","Experience everything that TV has to offer with this 24-inch LED smart TV from RCA. The built-in Roku app lets you control the TV directly through your smartphone for great control and ease of use. You can also cast photos, videos, music and more directly from your compatible mobile device right onto the television.","https://i5.walmartimages.ca/images/Thumbnails/332/475/6000204332475.jpg","$950","Black","TV", "10"),
        new ShopItem(3, "RCA HD LED TV", "The RCA LED HD 32 delivers prime picture quality and enhanced connectivity while reducing your power consumption.","The RCA LED HD 32 delivers prime picture quality and enhanced connectivity while reducing your power consumption.By using LED as its primary light source, the LED Back Lit 60Hz TV offers a high contrast ratio, vivid colors and a slim depth.","https://i5.walmartimages.ca/images/Thumbnails/040/333/6000200040333.jpg","$550","Black","TV", "10"),
        new ShopItem(4, "RCA 40 LED HD SMART TV, 1080p", "Versatility and performance collide with the RCA 40” Full HD Smart TV that comes loaded with apps a full array backlight for better contrast and uniformity, brilliant 1080p Full HD resolution and an ultra-fast processor.","Versatility and performance collide with the RCA 40” Full HD Smart TV that comes loaded with apps a full array backlight for better contrast and uniformity, brilliant 1080p Full HD resolution and an ultra-fast processor. With Live TV and many streaming options. Stream from Netflix, YouTube, or choose from many more streaming channels. With 3 HDMI ports easily connect your gaming console to enhance your gaming experience. This TV offers unparalleled entertainment in a size that fits your lifestyle.","https://i5.walmartimages.ca/images/Thumbnails/324/293/6000204324293.jpg","$650","Black","TV", "10"),
        new ShopItem(5, "Samsung Crystal Display 4K UltraHD Smart TV - TU7000", "The TV’s sleek, minimalistic style draws you into a pure cinematic experience – so you see the picture, not the TV.","The TV’s sleek, minimalistic style draws you into a pure cinematic experience – so you see the picture, not the TV. Control your TV and compatible devices with a single remote that recognizes your other devices as soon as you connect them. High-Dynamic Range allows you to see stunning detail in every scene, while Crystal Display delivers lifelike colour, optimal picture performance and immersive viewing. You’ll feel like you’re part of the film you’re watching.","https://i5.walmartimages.ca/images/Thumbnails/740/455/6000203740455.jpg","$750","Black","TV", "10"),
        new ShopItem(6, "blackweb Wired RGB", "Prepare to immerse yourself in blackweb. Our range of electronics and accessories are meticulously designed to take your experience to the next level.","Prepare to immerse yourself in blackweb. Our range of electronics and accessories are meticulously designed to take your experience to the next level.Get your game on with blackweb’s range of gaming accessories. Designed to enhance your gaming experience, each product combines the latest technology with easy to use functionality for the ultimate in powerful play.","https://i5.walmartimages.ca/images/Thumbnails/723/984/6000203723984.jpg","$32","Black","Electronics", "10"),
        new ShopItem(7, "Razer - Basilisk Hyperspeed Gaming Mouse (PC)", "Ultra-Fast Razer™ HyperSpeed Wireless Technology Faster than other wired gaming mice Razer™ 5G Advanced Optical Sensor For cutting-edge precision","Ultra-Fast Razer™ HyperSpeed Wireless Technology Faster than other wired gaming mice Razer™ 5G Advanced Optical Sensor For cutting-edge precision Ultra-Long Battery Life For extended performance Razer™ Mechanical Mouse Switches For durability of up to 50 Million Clicks 6 Programmable Buttons For extended controls Onboard DPI Storage For personalized settings wherever you go Untethered Lethal Precision","https://i5.walmartimages.ca/images/Thumbnails/725/032/6000204725032.jpg","$79","Black","Electronics", "10"),
        new ShopItem(8, "M65 PRO RGB", "La souris de jeu réglable CORSAIR M65 PRO RGB est une souris hautement personnalisable idéale pour les jeux FPS avec un système de poids réglable, un cadre en aluminium durable et un capteur optique de 12 000 DPI","La souris de jeu réglable CORSAIR M65 PRO RGB est une souris hautement personnalisable idéale pour les jeux FPS avec un système de poids réglable, un cadre en aluminium durable et un capteur optique de 12 000 DPI","https://i5.walmartimages.ca/images/Thumbnails/390/985/6000204390985.jpg","$69","Black","Electronics", "10"),
        new ShopItem(9, "Logitech G502 Hero High Performance", "High performance HERO 16K Sensor: Logitech's most accurate sensor yet with up to 16,000 DPI for the ultimate in gaming speed, accuracy and responsiveness across entire DPI range.","High performance HERO 16K Sensor: Logitech's most accurate sensor yet with up to 16,000 DPI for the ultimate in gaming speed, accuracy and responsiveness across entire DPI range. 11 Customizable Buttons and Onboard Memory: Assign custom commands to the buttons and save up to five ready to play profiles directly to the mouse. Zero smoothing/acceleration/filtering. Adjustable Weight System: Arrange up to five removable 3.6 grams weights inside the mouse for personalized weight and balance tuning. Programmable RGB Lighting and LIGHTSYNC Technology: Customize lighting from nearly 16.8 million colors to match your team's colors, sport your own or sync colors with other Logitech G gear. Mechanical Switch Button Tensioning: Metal spring tensioning system and pivot hinges are built into left and right gaming mouse buttons for a crisp, clean click feel with rapid click feedback.","https://i5.walmartimages.ca/images/Thumbnails/500/618/6000202500618.jpg","$99","Black","Electronics", "10"),
        new ShopItem(10, "Razer Viper Ultimate", "Ultra-Fast Razer™ HyperSpeed Wireless Technology Faster than wired gaming mice Razer™ Focus+ 20K Optical Sensor","Ultra-Fast Razer™ HyperSpeed Wireless Technology Faster than wired gaming mice Razer™ Focus+ 20K Optical Sensor For cutting-edge precision 74g Lightweight - Designed for Esports For swifter, controlled swipes Razer™ Optical Mouse Switch For actuation at the speed of light Up to 70 Hours of Battery Life For non-stop gaming","https://i5.walmartimages.ca/images/Thumbnails/725/160/6000204725160.jpg","$150","Black","Electronics", "10"),
        new ShopItem(11, "Apple AirPods with charging case", "With more talk time and voice-activated Siri access² and complete with Wireless Charging Case","With more talk time and voice-activated Siri access² and complete with Wireless Charging Case, AirPods deliver an unparalleled wireless headphone experience. Simply take them out and they’re ready to use with all your devices³. Put them in your ears and they connect immediately, immersing you in rich, high-fidelity sound. Just like magic.","https://i5.walmartimages.ca/images/Thumbnails/965/231/6000199965231.jpg","$160","Black","AirPods", "10"),
        new ShopItem(12, "New AirPods Pro (with MagSafe Charging Case)", "AirPods Pro feature Active Noise Cancellation for immersive sound.","AirPods Pro feature Active Noise Cancellation for immersive sound. Transparency mode for hearing the world around you. They’re sweat- and water-resistant,1 and have a customizable fit for all-day comfort.","https://i5.walmartimages.ca/images/Thumbnails/354/640/6000204354640.jpg","$275","Black","AirPods", "10"),
        new ShopItem(13, "Borne True Wireless Stereo Earbuds", "True wireless stereo earbuds with high resolution sound quality","In-ear design, Bluetooth V5.0, Microphone for handsfree stereo calling, Charging case, iPhone & Android compatible","https://i5.walmartimages.ca/images/Thumbnails/548/118/6000200548118.jpg","$10","Black","AirPods", "10"),
        new ShopItem(14, "New AirPods (3rd generation)", "Introducing the all-new AirPods. Featuring spatial audio that places sound all around you","Introducing the all-new AirPods. Featuring spatial audio that places sound all around you, Adaptive EQ that tunes music to your ears, and longer battery life. It’s all sweat- and water-resistant, and delivers an experience that’s simply magical.","https://i5.walmartimages.ca/images/Thumbnails/354/628/6000204354628.jpg","$150","Black","AirPods", "10"),
        new ShopItem(15, "SteelSeries Arctis 7 Black", "Arctis 7 is the PC Gamer’s Best Wireless Gaming Headset","Arctis 7 is the PC Gamer’s Best Wireless Gaming Headset, featuring rock solid, lossless 2.4GHz wireless, DTS Headphone:X v2.0 surround sound, and ClearCast, the best mic in gaming.","https://i5.walmartimages.ca/images/Thumbnails/712/091/6000204712091.jpg","$150","Black","HeadPhones", "10"),
        new ShopItem(16, "Acer Nitro Gaming Headset", "To be competitive on the international stage","To be competitive on the international stage, you need to hear EVERYTHING, from the footsteps of your prey to the call of a bird in the distance. So strap on your Predator Headset and let our tournament-grade soundscape take you to the next level of hearing. Let the hunt begin!","https://i5.walmartimages.ca/images/Thumbnails/951/872/6000199951872.jpg","$150","Black","HeadPhones", "11"),
        new ShopItem(17, "Gaming Earphone Gaming", "Primary kind of gaming headset, perfect for playing games, listening music, etc.","Primary kind of gaming headset, perfect for playing games, listening music, etc. Soft cushion head-pad and ear-pad, as well as adjustable length hinges guarantee hours of gaming comfort. Delivers clear sound and Deep Bass for Real Game.","https://i5.walmartimages.com/asr/3ad5434a-1e67-424b-b49e-6765207b3e49_1.e7d3513dd9b51eb34f9694b9d4405e79.jpeg?odnHeight=180&odnWidth=180&odnBg=ffffff","$23","Black","HeadPhones", "10"),
        new ShopItem(18, "Logitech G733 LIGHTSPEED", "LIGHTSPEED Wireless: Play for up to 29 hours and a range of up to 15 meters.","LIGHTSPEED Wireless: Play for up to 29 hours and a range of up to 15 meters. Play in stereo on PlayStationⓇ 4.Front-facing customizable LIGHTSYNC RGB lighting with ~16.8M colors. Comfy and adjustable, reversible, soft headband","https://i5.walmartimages.ca/images/Thumbnails/600/608/6000204600608.jpg","$200","Black","AirPods", "10"),
        new ShopItem(19, "Logitech USB Headset H340", "The perfect everyday headset with a simple plug-and-play USB connection.","The perfect everyday headset with a simple plug-and-play USB connection. Without the need to install software, you’re ready to go. A noise-canceling microphone reduces background noise and delivers clear digital audio for VOIP and Skype calls. Discreet and right-sided boom can be tucked inside the headband and out of the way when you’re not using it.","https://i5.walmartimages.ca/images/Thumbnails/209/490/1209490.jpg","$35","Black","HeadPhones", "10"),
        new ShopItem(20, "Logitech G432 7.1 Surround", "Immerse yourself in the game with the Logitech G432 gaming headset.","Immerse yourself in the game with the Logitech G432 gaming headset. Boasting powerful 50mm drivers and DTS Headphone:X 2.0 surround sound, this headset delivers rich sound with detailed clarity so you don't miss a thing. Comfortable over-ear design features raotating leatherette ear cups, ideal for extended gaming sessions.","https://i5.walmartimages.ca/images/Thumbnails/961/637/6000199961637.jpg","$60","Black","HeadPhones", "10")

    };

/// Create Method
public async Task CreateAsynce (ShopItem newShopItem){
    ShopItems.Add(newShopItem);
}

public async Task CreatebykeysAsynce (string Name, string ShortDescription, string Description, string Picture, string Price, string Option, string Category, string Quantity){
    int Id = ShopItems.Count();
    Id = Id+1;
    ShopItem newShopItem = new ShopItem (Id, Name, ShortDescription, Description, Picture, Price, Option, Category, Quantity);
    ShopItems.Add(newShopItem);

    }


/// Get all method
public async Task<List<ShopItem>> GetAsync(){
    return ShopItems;
}

/// get one method
public async Task<ShopItem> GetAsync( int Id){

    return ShopItems.Find(x => x.Id == Id);
}
/// Update method
public async Task<bool> UpdateAsync (int Id, ShopItem UpdatedShopItem){
    bool result = false;
    int index = ShopItems.FindIndex(x=> x.Id == Id);
    if (index != -1){
        UpdatedShopItem.Id = Id;
        ShopItems[index]= UpdatedShopItem;
        result=true;
    }

    return result;

}


/// Detele method
public async Task<bool> DeleteAsync(int Id){
    bool result = false;
    int index = ShopItems.FindIndex(x=> x.Id == Id);
    if (index != -1){
        ShopItems.RemoveAt(index);
        result=true;
    }

    return result;

}





}