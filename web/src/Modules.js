import React from 'react';
import PropTypes from 'prop-types';
import {withStyles} from '@material-ui/core/styles';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import {Link} from 'react-router-dom';
import Placeholder from './images/Placeholder.png';
import Grid from "@material-ui/core/Grid";

const styles = theme => ({
    root: {
        flex: 1,
        width: '100%',
        backgroundColor: theme.palette.secondary.main,
    },
    container: {
        justifyContent: 'space-around',
    },
    card: {
        marginTop: '3%',
        width: 345,

    },
    media: {
        height: 140,
    },


});


class Modules extends React.Component {
    render() {
        const {classes} = this.props;

        return (

            <div className={classes.root}>
                <Grid container className={classes.container}>
                    <Grid item xs={12} sm={6} md={3} lg={3}>
                        <Card className={classes.card}>
                            <CardActionArea>
                                <CardMedia
                                    className={classes.media}
                                    image={Placeholder}
                                    title="Contemplative Reptile"
                                />
                                <CardContent className={classes.info}>
                                    <Typography gutterBottom variant="h5" component="h2">
                                        Math Module
                                    </Typography>
                                    <Typography component="p">
                                        Our math module will go here it will be comprised of the visualization of a line
                                        integral in 3D space
                                    </Typography>
                                </CardContent>
                            </CardActionArea>
                            <CardActions>
                                <Link to='/simulation'>
                                    <Button size="small" color="primary">
                                        Start!
                                    </Button>
                                </Link>
                            </CardActions>
                        </Card>
                    </Grid>
                    <Grid item xs={12} sm={6} md={3} lg={3}>
                        <Card className={classes.card}>
                            <CardActionArea>
                                <CardMedia
                                    className={classes.media}
                                    image={Placeholder}
                                    title="Contemplative Reptile"
                                />
                                <CardContent className={classes.info}>
                                    <Typography gutterBottom variant="h5" component="h2">
                                        Physics Module
                                    </Typography>
                                    <Typography component="p">
                                        Our physics module will build upon our math module and explain flux using line
                                        integrals.
                                    </Typography>
                                </CardContent>
                            </CardActionArea>
                            <CardActions>
                                <Link to='/simulation'>
                                    <Button size="small" color="primary">
                                        Start!
                                    </Button>
                                </Link>
                            </CardActions>
                        </Card>
                    </Grid>
                </Grid>
            </div>
        );
    }
}

Modules.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles, {withTheme: true})(Modules);