
import Button from "@mui/material/Button";
import { Menu } from "../../app/model/menu";
import Grid from '@mui/material/Grid'; // Grid version 1
import Card from '@mui/material/Card';
import CardMedia from '@mui/material/CardMedia';
import CardContent from '@mui/material/CardContent';
import { useEffect, useState } from "react";
import { NavLink } from 'react-router-dom';
import agent from "../../app/api/agent";
import LoadingComponents from "../../app/layout/LoadingComponent";
import Footer from "../homePage/Footer";

const menuLinks = [
    { title: 'exercises', path: '/exercises' },
    { title: 'food', path: '/food' },
    { title: 'yoga', path: '/yoga' },
    { title: 'sleephygiene', path: '/sleep' },
    { title: 'mental health', path: '/doctors' }
]

export default function MainMenu() {
    const [menu, setMenu] = useState<Menu[]>([]);
    const [loading, setLoading] = useState(true);
    // if(loading) return LoadingComponents
    useEffect(() => {
        agent.MainMenu.list().then(menu => setMenu(menu))
            .catch(error => console.log(error))
            .finally(() => setLoading(false))
    }, [])
    if (loading) return <LoadingComponents message="Loading menu" />
    return (
        <div>

            <Grid container direction="row" justifyContent="center"  >
                {menu.map((menu) => (
                    <Grid style={{ margin: 30 }} key={menu.menuListId}>
                        <Card sx={{ width: 300 }}>
                            <CardMedia
                                sx={{ height: 500 }}
                                image={menu.menuListImg}
                            />
                        </Card>
                    </Grid>
                ))}
            </Grid>
            <Grid container direction="row" justifyContent="center">
                {menuLinks.map(({ title, path }) => (
                    <Grid style={{ margin: 30 }} key={path}>
                        <Card sx={{ width: 300 }}>
                            <CardContent>
                                <Button color="inherit" component={NavLink} to={path}> {title}</Button>
                            </CardContent>
                        </Card>
                    </Grid>
                ))}
            </Grid>
            <Footer/>
        </div>



    )
} 