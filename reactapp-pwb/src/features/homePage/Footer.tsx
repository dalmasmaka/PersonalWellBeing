import { TableFooter, Box, Grid, Typography } from "@mui/material";
import LocationOnIcon from '@mui/icons-material/LocationOn';
import EmailIcon from '@mui/icons-material/Email';
import CopyrightIcon from '@mui/icons-material/Copyright';
import CallIcon from '@mui/icons-material/Call';

export default function Footer(){
    return( 
    <>
     <TableFooter sx={{ height: 50 }} />
    <Box sx={{ flexGrow: 1, bgcolor: "#D5D1CC", height: 400, mt: 20 }}>
      <Grid container spacing={2} columns={16} marginTop={5}>
        <Grid item xs marginLeft={30}  >
          <Typography variant="h4" gutterBottom >
            About Us
          </Typography>
          <Typography fontSize={15}  >
            {'This platform aims to guide all those interested in a very healthy lifestyle. '}
            {'We offer the user different types of exercises, many healthy recipes based on preferences and care values, solutions for sleep problems to relieve stress and knowledge on meditation, then we offer services and knowledge on the aspects of yoga, everything which also helps us relax the mind and body.'}
            {' The main point of this platform that is offered to the user is the discussion with the best specialists/psychologists of the country and the possibility to determine a physical or virtual term based on the users preferences and comfort.'}
            {'The footer will move as the main element of the page grows.'}
          </Typography>
        </Grid>
        <Grid item xs marginLeft={10}>
          <Box display="flex" sx={{ margin: 3 }}>
            <LocationOnIcon />
            <Typography fontSize={15}  >
              {'Rr. 28 Nëntori, Prishtinë, Kosova'}
            </Typography>
          </Box>
          <Box display="flex" sx={{ margin: 3 }}>
            <CallIcon />
            <Typography fontSize={15}>
              {'+383 49 736 230'}
            </Typography>
          </Box>
          <Box display="flex" sx={{ margin: 3 }}>
            <EmailIcon />
            <Typography fontSize={15}  >
              {'smakadalma@gmail.com'}
            </Typography>
          </Box>
        </Grid>
      </Grid>
      <Box display="flex" sx={{ marginLeft: 110, marginTop: 10 }}>
        <CopyrightIcon style={{ width: 15, height: 15 }} />
        <Typography>Copyrights reserved 2022</Typography>
      </Box>

    </Box>
    </>
   
    );
}