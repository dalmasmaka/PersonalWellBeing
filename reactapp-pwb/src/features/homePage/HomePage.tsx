import { Box, Grid, TableFooter, Typography } from "@mui/material";
import Footer from "./Footer";

import MainFeaturedPost from "./MainFeaturedPost";




export default function HomePage() {

  const img = require("../../features/homePage/images/homePageImg.jpg");
  const mainFeaturedPost = {
    title: '',
    image: img,
    imageText: 'main image description',
    linkText: '',
  };
  return (

    <>
      <MainFeaturedPost post={mainFeaturedPost} />
      <Typography variant="h2" align="center">Personal Well Being</Typography>
      <hr style={{ width: "20%" }} />
    <Footer/>
     
    </>

  );
}