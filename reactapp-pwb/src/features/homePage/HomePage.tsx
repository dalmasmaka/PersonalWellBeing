import { Card, CardMedia, Container, Grid, Typography } from "@mui/material";
import { Box } from "@mui/system";
import MainFeaturedPost from "./MainFeaturedPost";



export default function HomePage() {
  
    const img = require("../../features/homePage/images/homePageImg.jpg");
    const mainFeaturedPost = {
        title: 'Personal Well Being',
        description:
          "Multiple lines of text that form the lede, informing new readers quickly and efficiently about what's most interesting in this post's contents.",
        image: img,
        imageText: 'main image description',
        linkText: 'Continue reading…',
      };    
  return (
    
   <main>
          <MainFeaturedPost post={mainFeaturedPost} />
         
        </main>
    
         

  );
}