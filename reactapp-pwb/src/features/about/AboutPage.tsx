import { Container, Paper, Typography } from "@mui/material";
import Footer from "../homePage/Footer";

export default function AboutPage(){

    return(
      <>
              <Container>
            <>
            <Typography variant="h1" gutterBottom  >
              About us
            </Typography>
            <Typography variant="h5"  >
              {'This platform aims to guide all those interested in a very healthy lifestyle. '}
              {'We offer the user different types of exercises, many healthy recipes based on preferences and care values, solutions for sleep problems to relieve stress and knowledge on meditation, then we offer services and knowledge on the aspects of yoga, everything which also helps us relax the mind and body.'}
              {' The main point of this platform that is offered to the user is the discussion with the best specialists/psychologists of the country and the possibility to determine a physical or virtual term based on the users preferences and comfort.'}
            </Typography>
            </>
        </Container>
        <Footer/>
      </>

    )
}