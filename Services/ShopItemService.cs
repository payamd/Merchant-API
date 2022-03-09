using Merchant_API.models;

namespace Merchant_API.services;

public class ShopItemService{

    /// ctor
    public ShopItemService()
    {
        
    }


///Default Values
    private List<ShopItem> ShopItems= new List<ShopItem> () {
        new ShopItem(1, "LG 4K UltraHD HDR LED Smart TV - UP7100", "Put your entertainment on full display with LG's UP7100 UHD TV that is engineered to enhance color, contrast, clarity and detail.","Put your entertainment on full display with LG's UP7100 UHD TV that is engineered to enhance color, contrast, clarity and detail. This smart TV also provides compatibility with Google Home, Alexa and Apple HomeKit for convenient control of your entertainment experience.","https://i5.walmartimages.ca/images/Thumbnails/270/845/6000203270845.jpg","$999","Black","TV", "10"),
        new ShopItem(2, "RCA 24-INCH ROKU SMART TV", "xperience everything that TV has to offer with this 24-inch LED smart TV from RCA.","Experience everything that TV has to offer with this 24-inch LED smart TV from RCA. The built-in Roku app lets you control the TV directly through your smartphone for great control and ease of use. You can also cast photos, videos, music and more directly from your compatible mobile device right onto the television.","https://i5.walmartimages.ca/images/Thumbnails/332/475/6000204332475.jpg","$950","Black","TV", "10"),
        new ShopItem(3, "RCA HD LED TV", "The RCA LED HD 32 delivers prime picture quality and enhanced connectivity while reducing your power consumption.","The RCA LED HD 32 delivers prime picture quality and enhanced connectivity while reducing your power consumption.By using LED as its primary light source, the LED Back Lit 60Hz TV offers a high contrast ratio, vivid colors and a slim depth.","https://i5.walmartimages.ca/images/Thumbnails/040/333/6000200040333.jpg","$550","Black","TV", "10"),
        new ShopItem(4, "RCA 40 LED HD SMART TV, 1080p", "Versatility and performance collide with the RCA 40” Full HD Smart TV that comes loaded with apps a full array backlight for better contrast and uniformity, brilliant 1080p Full HD resolution and an ultra-fast processor.","Versatility and performance collide with the RCA 40” Full HD Smart TV that comes loaded with apps a full array backlight for better contrast and uniformity, brilliant 1080p Full HD resolution and an ultra-fast processor. With Live TV and many streaming options. Stream from Netflix, YouTube, or choose from many more streaming channels. With 3 HDMI ports easily connect your gaming console to enhance your gaming experience. This TV offers unparalleled entertainment in a size that fits your lifestyle.","https://i5.walmartimages.ca/images/Thumbnails/324/293/6000204324293.jpg","$650","Black","TV", "10"),
        new ShopItem(5, "Samsung Crystal Display 4K UltraHD Smart TV - TU7000", "The TV’s sleek, minimalistic style draws you into a pure cinematic experience – so you see the picture, not the TV.","The TV’s sleek, minimalistic style draws you into a pure cinematic experience – so you see the picture, not the TV. Control your TV and compatible devices with a single remote that recognizes your other devices as soon as you connect them. High-Dynamic Range allows you to see stunning detail in every scene, while Crystal Display delivers lifelike colour, optimal picture performance and immersive viewing. You’ll feel like you’re part of the film you’re watching.","https://i5.walmartimages.ca/images/Thumbnails/740/455/6000203740455.jpg","$750","Black","TV", "10"),
        new ShopItem(6, "blackweb Wired RGB", "Prepare to immerse yourself in blackweb. Our range of electronics and accessories are meticulously designed to take your experience to the next level.","Prepare to immerse yourself in blackweb. Our range of electronics and accessories are meticulously designed to take your experience to the next level.Get your game on with blackweb’s range of gaming accessories. Designed to enhance your gaming experience, each product combines the latest technology with easy to use functionality for the ultimate in powerful play.","https://i5.walmartimages.ca/images/Thumbnails/723/984/6000203723984.jpg","$32","Black","Electronics", "10"),
        new ShopItem(7, "Razer - Basilisk Hyperspeed Gaming Mouse (PC)", "Ultra-Fast Razer™ HyperSpeed Wireless Technology Faster than other wired gaming mice Razer™ 5G Advanced Optical Sensor For cutting-edge precision","Ultra-Fast Razer™ HyperSpeed Wireless Technology Faster than other wired gaming mice Razer™ 5G Advanced Optical Sensor For cutting-edge precision Ultra-Long Battery Life For extended performance Razer™ Mechanical Mouse Switches For durability of up to 50 Million Clicks 6 Programmable Buttons For extended controls Onboard DPI Storage For personalized settings wherever you go Untethered Lethal Precision","https://i5.walmartimages.ca/images/Thumbnails/725/032/6000204725032.jpg","$79","Black","Electronics", "10"),
        new ShopItem(8, "M65 PRO RGB", "La souris de jeu réglable CORSAIR M65 PRO RGB est une souris hautement personnalisable idéale pour les jeux FPS avec un système de poids réglable, un cadre en aluminium durable et un capteur optique de 12 000 DPI","La souris de jeu réglable CORSAIR M65 PRO RGB est une souris hautement personnalisable idéale pour les jeux FPS avec un système de poids réglable, un cadre en aluminium durable et un capteur optique de 12 000 DPI","https://i5.walmartimages.ca/images/Thumbnails/390/985/6000204390985.jpg","$69","Black","Electronics", "10"),
        new ShopItem(9, "Logitech G502 Hero High Performance", "High performance HERO 16K Sensor: Logitech's most accurate sensor yet with up to 16,000 DPI for the ultimate in gaming speed, accuracy and responsiveness across entire DPI range.","High performance HERO 16K Sensor: Logitech's most accurate sensor yet with up to 16,000 DPI for the ultimate in gaming speed, accuracy and responsiveness across entire DPI range. 11 Customizable Buttons and Onboard Memory: Assign custom commands to the buttons and save up to five ready to play profiles directly to the mouse. Zero smoothing/acceleration/filtering. Adjustable Weight System: Arrange up to five removable 3.6 grams weights inside the mouse for personalized weight and balance tuning. Programmable RGB Lighting and LIGHTSYNC Technology: Customize lighting from nearly 16.8 million colors to match your team's colors, sport your own or sync colors with other Logitech G gear. Mechanical Switch Button Tensioning: Metal spring tensioning system and pivot hinges are built into left and right gaming mouse buttons for a crisp, clean click feel with rapid click feedback.","https://i5.walmartimages.ca/images/Thumbnails/500/618/6000202500618.jpg","$99","Black","Electronics", "10"),
        new ShopItem(10, "Razer Viper Ultimate", "Ultra-Fast Razer™ HyperSpeed Wireless Technology Faster than wired gaming mice Razer™ Focus+ 20K Optical Sensor","Ultra-Fast Razer™ HyperSpeed Wireless Technology Faster than wired gaming mice Razer™ Focus+ 20K Optical Sensor For cutting-edge precision 74g Lightweight - Designed for Esports For swifter, controlled swipes Razer™ Optical Mouse Switch For actuation at the speed of light Up to 70 Hours of Battery Life For non-stop gaming","https://i5.walmartimages.ca/images/Thumbnails/725/160/6000204725160.jpg","$150","Black","Electronics", "10")

    };

/// Create Method
public async Task CreateAsynce (ShopItem newShopItem){
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