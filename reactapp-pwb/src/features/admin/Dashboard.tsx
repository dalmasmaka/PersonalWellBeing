import * as React from 'react';
import Tabs from '@mui/material/Tabs';
import Tab from '@mui/material/Tab';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import Doctors from './Doctors/Doctors';
import { Container, Paper } from '@mui/material';
import Exercises from './Exercises/Exercises';
import NutritionFood from './Food/NutritionFood';
import Yogas from './Yoga/Yogas';
import Sleep from './SleepHygiene/Sleep';
import Footer from '../homePage/Footer';

interface TabPanelProps {
  children?: React.ReactNode;
  index: number;
  value: number;
}

function TabPanel(props: TabPanelProps) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`vertical-tabpanel-${index}`}
      aria-labelledby={`vertical-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box sx={{ p: 3 }}>
          <Typography>{children}</Typography>
        </Box>
      )}
    </div>
  );
}

function a11yProps(index: number) {
  return {
    id: `vertical-tab-${index}`,
    'aria-controls': `vertical-tabpanel-${index}`,
  };
}

export default function VerticalTabs() {
  const [value, setValue] = React.useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  return (
    <>
      <Box>
        <Box
          sx={{ flexGrow: 1, display: 'flex', minheight: "100%" }}
        >
          <Tabs
            orientation="vertical"
            variant="scrollable"
            value={value}
            onChange={handleChange}
            aria-label="Vertical tabs example"
            sx={{ borderRight: 1, borderColor: 'divider', minHeight: 800 }}
          >
            <Tab label="Dashboard" {...a11yProps(0)} />
            <Tab label="Doctors" {...a11yProps(1)} />
            <Tab label="Exercises" {...a11yProps(2)} />
            <Tab label="Nutrition Food" {...a11yProps(3)} />
            <Tab label="Yoga" {...a11yProps(4)} />
            <Tab label="Sleep Hygiene" {...a11yProps(5)} />
          </Tabs>
          <Container>

            <TabPanel value={value} index={0}>
              <Container>
                <Typography variant='h2'>{'Welcome back in your dashboard Admin!'}</Typography>
              </Container>

            </TabPanel>
            <TabPanel value={value} index={1}>
              <Doctors />

            </TabPanel>
            <TabPanel value={value} index={2}>
              <Exercises />
            </TabPanel>
            <TabPanel value={value} index={3}>
              <NutritionFood />
            </TabPanel>
            <TabPanel value={value} index={4}>
              <Yogas />
            </TabPanel>
            <TabPanel value={value} index={5}>
              <Sleep />
            </TabPanel>
          </Container>
        </Box>
      </Box>
    <Footer/>
    </>

  );
}
